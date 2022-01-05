using Miracles.Core;

namespace Miracles.Tests.Mocks
{
    internal class OneLineEpochConstants
    {
        public static IEpoch First { get; } = new OneLineEpoch(EpochNumber.First,
            new Card
            {
                DisplayName = "лесоповал",
                Effect = new Effect
                {
                    Resources = new Resources { Wood = 1 }
                }
            },
            new Card
            {
                DisplayName = "карьер",
                Cost = new Cost { Money = 1 },
                Effect = new Effect
                {  
                    Resources = new Resources { Brick = 1 }
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
                    Resources = new Resources { Brick = 1 }
                }
            });
    }
}