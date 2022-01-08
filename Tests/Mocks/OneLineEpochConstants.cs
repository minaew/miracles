using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Tests.Mocks
{
    internal static class OneLineEpochConstants
    {
        static OneLineEpochConstants()
        {
            var card1 = new CustomCard
            {
                DisplayName = "лесоповал"
            };
            card1.Effect.Resources.Add(ResourceKind.Wood);

            var card2 = new CustomCard
            {
                DisplayName = "карьер"
            };
            card2.Effect.Resources.Add(ResourceKind.Brick);

            var card3 = new CustomCard
            {
                DisplayName = "папирусная мастерская"
            };
            card3.Cost.Money = 1;
            card3.Effect.Resources.Add(ResourceKind.Brick);

            First = new OneLineEpoch(card1, card2, card3);
        }

        public static IEpoch First { get; }
    }
}
