using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Command
    {
        public CommandType Type { get; private set; }

        public Card Card { get; private set; } = new Card();

        public Wonder Wonder { get; private set; } = new Wonder();

        public static Command CardBuilding(Card card)
        {
            return new Command
            {
                Type = CommandType.CardBuilding,
                Card = card
            };
        }

        public static Command WonderBuilding(Wonder wonder, Card card)
        {
            return new Command
            {
                Type = CommandType.WonderBuilding,
                Wonder = wonder,
                Card = card
            };
        }

        public static Command CardTrashing(Card card)
        {
            return new Command
            {
                Type = CommandType.CardTrashing,
                Card = card
            };
        }

        public override string ToString()
        {
            return $"{Type}-{Card.DisplayName}";
        }
    }
}
