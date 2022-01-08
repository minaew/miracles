using Miracles.Core.Enums;

namespace Miracles.Core.Abstractions
{
    public interface ICard : ICostable
    {
        string DisplayName { get; }

        CardColor Color { get; }

        Effect Effect { get; }
    }
}
