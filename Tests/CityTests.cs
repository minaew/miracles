using Xunit;
using Miracles.Core;

namespace Miracles.Tests
{
    public class CityTests
    {
        [Fact]
        public void CanBuildFreeCard()
        {
            var city = new City();
            var freeCard = new Card();

            Assert.True(city.CanBuild(freeCard));
        }

        [Fact]
        public void CanBuildWithResources()
        {
            var city = new City();

            var resourceCard = new Card();
            resourceCard.Effect.Resource.Wood = 2;
            city.Build(resourceCard);

            var targetCard = new Card();
            targetCard.Cost.Resource.Wood = 1;
        
            Assert.True(city.CanBuild(targetCard));
        }

        [Fact]
        public void CantBuildWithoutResources()
        {
            var city = new City();
        
            var card = new Card();
            card.Cost.Resource.Wood = 1;

            Assert.False(city.Build(card));
        }

        [Fact]
        public void CantBuildWithWrongResources()
        {
            var city = new City();

            var resourceCard = new Card();
            resourceCard.Effect.Resource.Wood = 1;
            city.Build(resourceCard);

            var targetCard = new Card();
            targetCard.Cost.Resource.Brick = 1;

            Assert.False(city.CanBuild(targetCard));
        }
    }
}
