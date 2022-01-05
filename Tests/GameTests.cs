using System.Linq;

using Xunit;
using Xunit.Abstractions;

using Miracles.Core;
using Miracles.Tests.Mocks;

namespace Miracles.Tests
{
    public class GameTests
    {
        private readonly ITestOutputHelper _output;

        public GameTests(ITestOutputHelper outputHelper)
        {
            _output = outputHelper;
        }

        [Fact]
        public void EmptyEpochsIsTheEnd()
        {
            var game = new Game(new CustomEpochFactory());
            Assert.Equal(0, game.AvailableCommands.Count);
        }

        [Fact]
        public void EndToEnd()
        {
            var factory = new CustomEpochFactory();
            factory[EpochNumber.First] = OneLineEpochConstants.First;

            var game = new Game(factory);

            var commands = game.AvailableCommands;
            var firstTurnCount = commands.Count;
            Assert.NotEqual(0, firstTurnCount);

            var command = commands.First();
            Assert.Equal(CommandType.CardBuilding, command.Type);

            game.Invoke(command);
            commands = game.AvailableCommands;
            Assert.Equal(firstTurnCount - 2, commands.Count);
        }
    }
}
