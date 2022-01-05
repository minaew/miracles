using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Card
    {
        public string DisplayName { get; set; } = string.Empty;

        public CardColor Color { get; set; }

        public Cost Cost { get; set; } = new Cost();

        public Effect Effect { get; set; } = new Effect();
    }
}
