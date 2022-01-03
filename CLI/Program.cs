using System.Text.Json;
using System.Text.Json.Serialization;
using Miracles.Core;

namespace Miracles.CLI
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var game = new Game();
            game.Epoch = Epoch.First;

            DumpState(game);

            var card = game.Epoch.AvailableCards.First();
            game.Build(game.City1, card);

            DumpState(game);
        }

        private static void DumpState(Game game)
        {
            Console.WriteLine(JsonSerializer.Serialize(game, new JsonSerializerOptions
            {
                WriteIndented = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            }));
        }
    }
}
