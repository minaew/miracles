using System.Collections.Generic;

namespace Miracles.Core.Abstractions
{
    public interface IEpoch
    {
        IReadOnlyCollection<Card> AvailableCards { get; }

        void Remove(Card card);
    }
}
