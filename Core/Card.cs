using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    internal class Card : ICard
    {
        public Card(string displayName, CardColor color, Effect effect)
            : this(displayName, color, effect, new Cost(0))
        {
        }

        public Card(string displayName, CardColor color, Effect effect, Cost cost)
        {
            DisplayName = displayName;
            Color = color;
            Effect = effect;
            Cost = cost;
        }

        public string DisplayName { get; }

        public CardColor Color { get; }

        public Cost Cost { get; }

        public Effect Effect { get; }
    }
}
