using System.Collections.Generic;

namespace Miracles.Core.Abstractions
{
    public interface ICity
    {
        IReadOnlyCollection<Wonder> AvailableWonders { get; }

        int Scores { get; }

        int CivilScores { get; }

        bool CanBuild(ICostable costable);

        bool Build(ICard card);

        bool Build(Wonder wonder);

        void Trash();

        void Loot(int money);
    }
}
