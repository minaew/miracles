using System.Collections.Generic;
using Miracles.Core.Abstractions;

namespace Miracles.Core
{
    // TODO: implement epoch pattern with card blocking and discovery
    public class Epoch : IEpoch
    {
        public IReadOnlyCollection<ICard> AvailableCards { get; } = new List<ICard>();

        public void Remove(ICard card)
        {
        }
    }
}
