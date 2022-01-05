using System.Collections.Generic;
using Miracles.Core.Abstractions;

namespace Miracles.Core
{
    // TODO: implement epoch pattern with card blocking and discovery
    public class Epoch : IEpoch
    {   
        public IReadOnlyCollection<Card> AvailableCards { get; } = new List<Card>();

        public void Remove(Card card)
        {
        }
    }
}
