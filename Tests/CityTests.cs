using Xunit;
using Miracles.Core;
using Miracles.Core.Enums;
using Miracles.Tests.Mocks;

namespace Miracles.Tests
{
    public class CityTests
    {
        [Fact]
        public void CanBuildFreeCard()
        {
            var city = City.CreatePair().Item1;
            var freeCard = new CustomCard();

            Assert.True(city.CanBuild(freeCard));
        }

        [Fact]
        public void CanBuildWithResources()
        {
            var city = City.CreatePair().Item1;

            var resourceCard = new CustomCard();
            resourceCard.Effect.Resources.Add(ResourceKind.Wood);
            resourceCard.Effect.Resources.Add(ResourceKind.Wood);
            city.Build(resourceCard);

            var targetCard = new CustomCard();
            targetCard.Cost.Resources.Add(ResourceKind.Wood);

            Assert.True(city.CanBuild(targetCard));
        }

        [Fact]
        public void CantBuildWithoutResources()
        {
            var city = City.CreatePair().Item1;

            var card = new CustomCard();
            card.Cost.Resources.Add(ResourceKind.Wood);

            Assert.False(city.CanBuild(card));
        }

        [Fact]
        public void CantBuildWithWrongResources()
        {
            var city = City.CreatePair().Item1;

            var resourceCard = new CustomCard();
            resourceCard.Effect.Resources.Add(ResourceKind.Wood);
            city.Build(resourceCard);

            var targetCard = new CustomCard();
            targetCard.Cost.Resources.Add(ResourceKind.Brick);

            Assert.False(city.CanBuild(targetCard));
        }

        [Fact]
        public void CanBuildWithDiscount()
        {
            var city = City.CreatePair().Item1;
            city.Money = 3;

            var card = new CustomCard();
            card.Effect.Discount.Add(ResourceKind.Wood);
            city.Build(card);

            var targetCard = new CustomCard();
            targetCard.Cost.Resources.Add(ResourceKind.Wood);
            targetCard.Cost.Resources.Add(ResourceKind.Wood);
            targetCard.Cost.Resources.Add(ResourceKind.Wood);

            Assert.True(city.CanBuild(targetCard));
        }

        [Fact]
        public void CantBuildWithWrongDiscount()
        {
            var city = City.CreatePair().Item1;
            city.Money = 3;

            var card = new CustomCard();
            card.Effect.Discount.Add(ResourceKind.Wood);
            city.Build(card);

            var targetCard = new CustomCard();
            targetCard.Cost.Resources.Add(ResourceKind.Brick);
            targetCard.Cost.Resources.Add(ResourceKind.Brick);
            targetCard.Cost.Resources.Add(ResourceKind.Brick);

            Assert.False(city.CanBuild(targetCard));
        }

        [Fact]
        public void CanBuildWithEnoughMoney()
        {
            var city = City.CreatePair().Item1;
            city.Money = 10;

            var card = new CustomCard();
            card.Cost.Money = 5;

            Assert.True(city.CanBuild(card));
        }

        [Fact]
        public void CantBuildWithoutEnoughMoney()
        {
            var city = City.CreatePair().Item1;
            city.Money = 5;

            var card = new CustomCard();
            card.Cost.Money = 10;

            Assert.False(city.CanBuild(card));
        }

        [Fact]
        public void CanBuildWithResourceBuying()
        {
            var city = City.CreatePair().Item1;
            city.Money = 6;
            city.ResourceCostCalculator = new CustomResourceCostCalculator
            {
                { ResourceKind.Wood, 5 }
            };

            var card = new CustomCard();
            card.Cost.Resources.Add(ResourceKind.Wood);

            Assert.True(city.CanBuild(card));
        }

        [Fact]
        public void CantBuildWithResourceBuying()
        {
            var city = City.CreatePair().Item1;
            city.Money = 3;
            city.ResourceCostCalculator = new CustomResourceCostCalculator
            {
                { ResourceKind.Wood, 5 }
            };

            var card = new CustomCard();
            card.Cost.Resources.Add(ResourceKind.Wood);

            Assert.False(city.CanBuild(card));
        }

        [Fact]
        public void CanBuildWithChain()
        {
            var city = City.CreatePair().Item1;

            var card = new CustomCard();
            card.Effect.Chain = ChainKind.Stables;
            city.Build(card);

            var targetCard = new CustomCard();
            targetCard.Cost.Chain = ChainKind.Stables;
            targetCard.Cost.Money = 100;

            Assert.True(city.CanBuild(targetCard));
        }

        [Fact]
        public void CantBuildWithWrongChain()
        {
            var city = City.CreatePair().Item1;

            var card = new CustomCard();
            card.Effect.Chain = ChainKind.Stables;
            city.Build(card);

            var targetCard = new CustomCard();
            targetCard.Cost.Chain = ChainKind.Barrel;
            targetCard.Cost.Money = 100;

            Assert.False(city.CanBuild(targetCard));
        }
    }
}
