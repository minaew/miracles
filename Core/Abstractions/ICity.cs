using System.Collections.Generic;

namespace Miracles.Core.Abstractions
{
    public interface ICity
    {
        IReadOnlyCollection<Wonder> AvailableWonders { get; }

        bool CanBuild(ICostable costable);

        bool Build(Card card);

        bool Build(Wonder wonder);

        void Trash();

        void Loot(int money);
    }
}
