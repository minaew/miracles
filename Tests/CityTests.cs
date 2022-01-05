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
            var builded = city.Build(new Card());
            Assert.True(builded);
        }

        [Fact]
        public void CantBuildWithoutResource()
        {
            var city = new City();
        
            var card = new Card();
            card.Cost.Resource = new Resource { Wood = 1 };

            Assert.False(city.Build(card));
        }
    }
}
