namespace Miracles.Core
{
    public class Game
    {
        private IEpochFactory _epochFactory;
        private IEpoch _epoch;
        private readonly ICollection<Card> _grave = new List<Card>();
        private IDictionary<Player, ICity> _cities = new Dictionary<Player, ICity>
        {
            { Player.First, new City() },
            { Player.Second, new City() }
        };
        private Player _turnOwner;

        public Game(IEpochFactory epochFactory)
        {
            _epochFactory = epochFactory;
            _epoch = _epochFactory[EpochNumber.First];
        }

        public IReadOnlyCollection<Command> AvailableCommands
        {
            get
            {
                while (_epoch.AvailableCards.Count == 0)
                {
                    switch (_epoch.Number)
                    {
                        case EpochNumber.First:
                            _epoch = _epochFactory[EpochNumber.Second];
                            break;

                        case EpochNumber.Second:
                            _epoch = _epochFactory[EpochNumber.Third];
                            break;
                    }
                }

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

        public void Invoke(Command action) // FIXME: id
        {
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
        }
    }
}