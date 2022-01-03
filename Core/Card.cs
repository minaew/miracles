namespace Miracles.Core
{
    public class Card
    {
        public string DisplayName { get; set; } = string.Empty;

        public Color Color { get; set; }

        public Cost Cost { get; set; } = new Cost();

        public Effect Effect { get; set; } = new Effect();
    }

    public enum Color
    {
        Yellow
    }

    public class Cost
    {
        public int Money { get; set; }

        public Resources Resources { get; set; } = new Resources();
    }

    public class Effect
    {
        public Resources Resources { get; set; } = new Resources();
    }

    public class Wonder
    {
        public Cost Cost { get; set; } = new Cost();
    }
}
