using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;
using Miracles.Core.Helpers;

namespace Miracles.Core
{
    public class Game
    {
        private EpochNumber _epochNumber;
        private readonly IEpochFactory _epochFactory;
        private IEpoch _epoch;
        private readonly Dictionary<Player, ICity> _cities = new();
        private Player _turnOwner;
        private readonly ICollection<ICard> _grave = new List<ICard>();
        private readonly IField _field;

        public Game(IEpochFactory epochFactory, IField field)
        {
            var cityPair = City.CreatePair();
            _cities[Player.First] = cityPair.Item1;
            _cities[Player.Second] = cityPair.Item2;

            _epochFactory = epochFactory;
            _epoch = _epochFactory[EpochNumber.First];

            _field = field;

            Update();
        }

        public IReadOnlyCollection<Command> AvailableCommands
        {
            get
            {
                var cards = _epoch.AvailableCards
                    .Where(c => _cities[_turnOwner].CanBuild(c))
                    .Select(c => Command.CardBuilding(c));

                var wonders = _cities[_turnOwner].AvailableWonders
                    .SelectMany(w => _epoch.AvailableCards
                                           .Select(c => Command.WonderBuilding(w, c)));

                var trash = _epoch.AvailableCards
                    .Select(c => Command.CardTrashing(c));

                return cards.Concat(wonders).Concat(trash).ToList();
            }
        }

        public VictoryType? Victory { get; private set; }

        public Player? Winner { get; private set; }

        public void Invoke(Command action) // FIXME: id
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var city = _cities[_turnOwner];

            int loss;
            switch (action.Type)
            {
                case CommandType.CardBuilding:
                    _epoch.Remove(action.Card);
                    city.Build(action.Card);
                    loss = _field.Add(_turnOwner, action.Card.Effect.Power);
                    _cities[_turnOwner.Other()].Loot(loss);
                    break;

                case CommandType.WonderBuilding:
                    _epoch.Remove(action.Card);
                    city.Build(action.Wonder);
                    loss = _field.Add(_turnOwner, action.Card.Effect.Power);
                    _cities[_turnOwner.Other()].Loot(loss);
                    break;

                case CommandType.CardTrashing:
                    _epoch.Remove(action.Card);
                    _grave.Add(action.Card);
                    city.Trash();
                    break;

                default:
                    throw new ArgumentException("invalid commandType");
            }

            _turnOwner = _turnOwner.Other();
            Update();
        }

        private void Update()
        {
            // war victory
            if (_field.Winner != null)
            {
                Victory = VictoryType.War;
                Winner = _field.Winner;
                return;
            }

            // TODO: science victory

            while ((_epoch?.AvailableCards.Count ?? 0) == 0)
            {
                if (_epochNumber == EpochNumber.Third)
                {
                    // last epoch -> game is over
                    Victory = VictoryType.Score;

                    // score victory
                    var first = 0;
                    var second = 0;

                    // military power
                    switch (_field.Scores.Item1)
                    {
                        case Player.First:
                            first += _field.Scores.Item2;
                            break;
                        case Player.Second:
                            second += _field.Scores.Item2;
                            break;
                    }

                    // from cards and wonders
                    first += _cities[Player.First].Scores;
                    second += _cities[Player.Second].Scores;
 
                    // TODO: violet cards

                    if (first > second)
                    {
                        Winner = Player.First;
                    }
                    if (second > first)
                    {
                        Winner = Player.Second;
                    }
                    if (second == first)
                    {
                        first = _cities[Player.First].CivilScores;
                        second = _cities[Player.Second].CivilScores;

                        if (first > second)
                        {
                            Winner = Player.First;
                        }
                        if (second > first)
                        {
                            Winner = Player.Second;
                        }
                        if (second == first)
                        {
                            Winner = null;
                        }
                    }

                    return;
                }

                // go to next epoch
                _epochNumber++;
                _epoch = _epochFactory[_epochNumber];
            }
        }
    }
}
