using System.Collections.Generic;
using Xunit;
using Miracles.Core;
using Miracles.Core.Enums;

namespace Miracles.Tests
{
    public class FieldTests
    {
        [Fact]
        public void FirsPlayerIncreasingToVictory()
        {
            var field = new Field();

            var losses = new List<int>();
            for (var i = 0; i < 9; i++)
            {
                var loss = field.Add(Player.First, 1);
                losses.Add(loss);
            }

            Assert.Equal(new [] {0, 0, 2, 0, 0, 5, 0, 0, 0 },
                         losses);

            Assert.Equal(Player.First, field.Winner);
        }

        [Fact]
        public void SecondGoDoNotBringLosses()
        {
            var field = new Field();
            for (var i = 0; i < 8; i++)
            {
                field.Add(Player.First, 1);
            }
            for (var i = 0; i < 8; i++)
            {
                field.Add(Player.Second, 1);
            }

            for (var i = 0; i < 9; i++)
            {
                var loss = field.Add(Player.First, 1);
                Assert.Equal(0, loss);
            }

            Assert.Equal(Player.First, field.Winner);
        }
    }
}
