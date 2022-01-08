using Miracles.Core;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace  Miracles.Tests.Mocks
{
    internal class CustomCard : ICard
    {
        public string DisplayName { get; set; } = "";

        public CardColor Color { get; set; }

        public Effect Effect { get; set; } = new Effect();

        public Cost Cost { get; set; } = new Cost(0);
    }
}
