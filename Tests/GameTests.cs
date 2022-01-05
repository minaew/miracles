using System.Linq;
using Xunit;
using Xunit.Abstractions;
using Miracles.Core;
using Miracles.Tests.Mocks;
using Miracles.Core.Enums;

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
        public void OneCardBuilding()
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

        [Fact]
        public void EmptyEpochs()
        {
            // Given
            var factory = new CustomEpochFactory();
            factory[EpochNumber.First] = new OneLineEpoch();
            var game = new Game(factory);
        
            // When
            PlayGame(game);

            // Then
            Assert.Equal(VictoryType.Score, game.Victory);
            Assert.Null(game.Winner);
        }

        private void PlayGame(Game game) // TODO: to abscrtaction?
        {
            while (game.Victory == null)
            {
                var nextCommand = game.AvailableCommands.First();
                game.Invoke(nextCommand);
            }
        }
    }
}
