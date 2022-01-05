using System.Collections.Generic;
using Miracles.Core;
using Miracles.Core.Abstractions;

namespace Miracles.Tests.Mocks
{
    public class OneLineEpoch : IEpoch
    {
        private readonly List<Card> _cards = new List<Card>();

        public OneLineEpoch(params Card[] cards)
        {
            _cards.AddRange(cards);
        }

        public IReadOnlyCollection<Card> AvailableCards => _cards;

        public void Remove(Card card)
        {
            _cards.Remove(card);
        }
    }
}
