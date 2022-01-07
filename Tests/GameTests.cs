using System.Linq;
using Xunit;
using Miracles.Core;
using Miracles.Tests.Mocks;
using Miracles.Core.Enums;

namespace Miracles.Tests
{
    public class GameTests
    {
        [Fact]
        public void OneCardBuilding()
        {
            var factory = new CustomEpochFactory();
            factory[EpochNumber.First] = OneLineEpochConstants.First;

            var game = new Game(factory, new Field());

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
            var game = new Game(factory, new Field());

            // When
            PlayGame(game);

            // Then
            Assert.Equal(VictoryType.Score, game.Victory);
            Assert.Null(game.Winner);
        }

        [Fact]
        public void MillitaryVictory()
        {
            var factory = new CustomEpochFactory();
            factory[EpochNumber.First] = OneLineEpochConstants.First;
            var game = new Game(factory, new Field());

            for (var i = 0; i < 9; i++)
            {
                var card = new Card();
                card.Effect.Power = 1;
                var command = Command.CardBuilding(card);
                game.Invoke(command);

                var blank = new Card();
                command = Command.CardBuilding(blank);
                game.Invoke(command);
            }

            Assert.Equal(VictoryType.War, game.Victory);
            Assert.Equal(Player.First, game.Winner);
        }

        private static void PlayGame(Game game) // TODO: to abscrtaction?
        {
            while (game.Victory == null)
            {
                var nextCommand = game.AvailableCommands.First();
                game.Invoke(nextCommand);
            }
        }
    }
}
