namespace Miracles.Core
{
    public class City
    {
        public ICollection<Card> Cards { get; } = new List<Card>();

        public ICollection<Wonder> Wonders { get; } = new List<Wonder>();

        public int Money { get; set; }

        // TODO: growth tokens

        public bool BuildCard(Card card)
        {
            var resources = Cards.Select(c => c.Effect.Resources).Aggregate(new Resources(), (r1, r2) => r1 + r2);
            var canBeBuilt = resources.Covers(card.Cost.Resources);
            // TODO: implement other ways
            // 0. resources from wonders
            // 1. buy resources
            // 2, build chain

            if (canBeBuilt)
            {
                Cards.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Trash()
        {
            Money += 2 + Cards.Count(c => c.Color == Color.Yellow);
        }

        public bool Buid(Wonder wonder)
        {
            var resources = Cards.Select(c => c.Effect.Resources).Aggregate((r1, r2) => r1 + r2);
            var canBeBuilt = resources.Covers(wonder.Cost.Resources);
            // TODO: implement other ways
            // 0. resources from wonders
            // 1. buy resources

            if (canBeBuilt)
            {
                Wonders.Add(wonder);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
