using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Game
    {
        private EpochNumber _epochNumber;
        private readonly IEpochFactory _epochFactory;
        private IEpoch _epoch;
        private readonly Dictionary<Player, ICity> _cities = new();
        private Player _turnOwner;
        private readonly ICollection<Card> _grave = new List<Card>();

        public Game(IEpochFactory epochFactory)
        {
            var cityPair = City.CreatePair();
            _cities[Player.First] = cityPair.Item1;
            _cities[Player.Second] = cityPair.Item2;

            _epochFactory = epochFactory;
            _epoch = _epochFactory[EpochNumber.First];

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

        public Player? Winner { get; }

        public void Invoke(Command action) // FIXME: id
        {
            if (action is null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            var city = _cities[_turnOwner];

            switch (action.Type)
            {
                case CommandType.CardBuilding:
                    _epoch.Remove(action.Card);
                    city.Build(action.Card);
                    break;

                case CommandType.WonderBuilding:
                    _epoch.Remove(action.Card);
                    city.Build(action.Wonder);
                    break;

                case CommandType.CardTrashing:
                    _epoch.Remove(action.Card);
                    _grave.Add(action.Card);
                    city.Trash();
                    break;

                default:
                    throw new ArgumentException("invalid commandType");
            }

            _turnOwner = _turnOwner == Player.First ? Player.Second : Player.First;
            Update();
        }

        private void Update()
        {
            while ((_epoch?.AvailableCards.Count ?? 0) == 0)
            {
                if (_epochNumber == EpochNumber.Third)
                {
                    // last epoch -> game is over
                    Victory = VictoryType.Score;
                    return;
                }

                // go to next epoch
                _epochNumber++;
                _epoch = _epochFactory[_epochNumber];
            }

            // TODO: war victory
            // TODO: science victory
        }
    }
}
