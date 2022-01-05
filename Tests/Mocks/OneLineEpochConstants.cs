using Miracles.Core;
using Miracles.Core.Abstractions;

namespace Miracles.Tests.Mocks
{
    internal class OneLineEpochConstants
    {
        public static IEpoch First { get; } = new OneLineEpoch(
            new Card
            {
                DisplayName = "лесоповал",
                Effect = new Effect
                {
                    Resource = new Resource { Wood = 1 }
                }
            },
            new Card
            {
                DisplayName = "карьер",
                Cost = new Cost { Money = 1 },
                Effect = new Effect
                {  
                    Resource = new Resource { Brick = 1 }
                }
            },
            new Card
            {
                DisplayName = "папирусная мастерская",
                Cost = new Cost
                {
                    Money = 1
                },
                Effect = new Effect
                {  
                    Resource = new Resource { Brick = 1 }
                }
            });
    }
}
