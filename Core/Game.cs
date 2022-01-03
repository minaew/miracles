namespace Miracles.Core
{
    public class Game
    {
        public Epoch Epoch { get; set; } = new Epoch();

        public ICollection<Card> Grave { get; } = new List<Card>();

        public City City1 { get; } = new City();

        public City City2 { get; } = new City();

        public void Build(City city, Card card)
        {
            city.BuildCard(card);
            Epoch.AvailableCards.Remove(card);
            Grave.Add(card);
        }
    }
}