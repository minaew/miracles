namespace Miracles.Core
{
    public class City : ICity
    {
        private int _money;
        private readonly List<Card> _cards = new List<Card>();
        private readonly IDictionary<Wonder, bool> _wonders = new Dictionary<Wonder, bool>();

        public IReadOnlyCollection<Wonder> AvailableWonders => _wonders
            .Where(w => w.Value).Select(w => w.Key).ToList();

        public bool CanBuild(Card card)
        {
            var resources = _cards.Select(c => c.Effect.Resources).Aggregate(new Resources(), (r1, r2) => r1 + r2);
            // TODO: implement other ways
            // 0. resources from wonders
            // 1. buy resources
            // 2, build chain
            return resources.Covers(card.Cost.Resources);
        }

        public bool Build(Card card)
        {
            if (CanBuild(card))
            {
                _cards.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Trash()
        {
            _money += 2 + _cards.Count(c => c.Color == Color.Yellow);
        }

        public bool CanBuild(Wonder wonder)
        {
            if (_wonders[wonder]) return true; // already built

            var resources = _cards.Select(c => c.Effect.Resources).Aggregate((r1, r2) => r1 + r2);
            // TODO: implement other ways
            // 0. resources from wonders
            // 1. buy resources
            return resources.Covers(wonder.Cost.Resources);
        }

        public bool Build(Wonder wonder)
        {
            if (CanBuild(wonder))
            {
                _wonders[wonder] = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
