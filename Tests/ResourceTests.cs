using System;
using System.Linq;
using Xunit;
using Miracles.Core.Enums;
using Miracles.Core.Helpers;

namespace Miracles.Tests
{
    public class ResourceTests
    {
        [Fact]
        public void CollectionExceptSameCollectionIsEmpty()
        {
            var collection = new []
            {
                ResourceKind.Wood, ResourceKind.Brick, ResourceKind.Stone
            };

            var difference = collection.Except(collection);
            Assert.Empty(difference);
        }

        [Fact]
        public void EmptyCollectionDifferenceIsEmpty()
        {
            var collection1 = Array.Empty<ResourceKind>();
            var collection2 = new []
            {
                ResourceKind.Wood, ResourceKind.Brick, ResourceKind.Stone
            };

            var difference = collection1.Except(collection2);
            Assert.Empty(difference);
        }

        [Fact]
        public void MultipleKindPreserves()
        {
            var collection1 = new [] { ResourceKind.Wood, ResourceKind.Wood };
            var collection2 = Array.Empty<ResourceKind>();

            var difference = collection1.Except(collection2);
            Assert.Equal(collection1, difference);
        }

        [Fact]
        public void NumberOfResourcesSubtracts()
        {
            var collection1 = Enumerable.Repeat(ResourceKind.Wood, 3);
            var collection2 = Enumerable.Repeat(ResourceKind.Wood, 2);

            var difference = collection1.Except(collection2);
            Assert.Equal(Enumerable.Repeat(ResourceKind.Wood, 1),
                         difference);
        }
    }
}
