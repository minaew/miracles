namespace Miracles.Core
{
    public class Epoch
    {
        public ICollection<Card> AvailableCards { get; set; } = new List<Card>();

        public static Epoch First { get; } = new Epoch
        {
            AvailableCards = new List<Card>
            {
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
                }
            }
        };
    }
}