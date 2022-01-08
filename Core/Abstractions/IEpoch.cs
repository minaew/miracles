using System.Collections.Generic;

namespace Miracles.Core.Abstractions
{
    public interface IEpoch
    {
        IReadOnlyCollection<ICard> AvailableCards { get; }

        void Remove(ICard card);
    }
}
