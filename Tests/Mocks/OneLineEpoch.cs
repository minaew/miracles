using System.Collections.Generic;
using Miracles.Core;

namespace Miracles.Tests.Mocks
{
    public class OneLineEpoch : IEpoch
    {
        private readonly List<Card> _cards = new List<Card>();

        public OneLineEpoch(EpochNumber number, params Card[] cards)
        {
            Number = number;
            _cards.AddRange(cards);
        }

        public EpochNumber Number { get; }

        public IReadOnlyCollection<Card> AvailableCards => _cards;

        public void Remove(Card card)
        {
            _cards.Remove(card);
        }
    }
}
