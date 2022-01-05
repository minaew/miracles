using Miracles.Core;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Tests.Mocks
{
    internal class OneLineEpochConstants
    {
        static OneLineEpochConstants()
        {
            var card1 = new Card();
            card1.DisplayName = "лесоповал";
            card1.Effect.Resource[ResourceKind.Wood] = 1;

            var card2 = new Card();
            card2.DisplayName = "карьер";
            card2.Effect.Resource[ResourceKind.Brick] = 1;

            var card3 = new Card();
            card3.DisplayName = "папирусная мастерская";
            card3.Cost.Money = 1;
            card3.Effect.Resource[ResourceKind.Brick] = 1;

            First = new OneLineEpoch(card1, card2, card3);
        }

        public static IEpoch First { get; }
    }
}
