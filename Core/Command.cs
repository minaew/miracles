using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Command
    {
        private Command(ICard card)
        {
            Card = card;
        }

        public CommandType Type { get; private set; }

        public ICard Card { get; }

        public Wonder Wonder { get; private set; } = new Wonder();

        public static Command CardBuilding(ICard card)
        {
            return new Command(card)
            {
                Type = CommandType.CardBuilding
            };
        }

        public static Command WonderBuilding(Wonder wonder, ICard card)
        {
            return new Command(card)
            {
                Type = CommandType.WonderBuilding,
                Wonder = wonder
            };
        }

        public static Command CardTrashing(ICard card)
        {
            return new Command(card)
            {
                Type = CommandType.CardTrashing
            };
        }

        public override string ToString()
        {
            return $"{Type}-{Card.DisplayName}";
        }
    }
}
