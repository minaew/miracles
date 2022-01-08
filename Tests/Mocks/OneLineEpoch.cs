using System.Collections.Generic;
using Miracles.Core;
using Miracles.Core.Abstractions;

namespace Miracles.Tests.Mocks
{
    public class OneLineEpoch : IEpoch
    {
        private readonly List<ICard> _cards = new();

        public OneLineEpoch(params ICard[] cards)
        {
            _cards.AddRange(cards);
        }

        public IReadOnlyCollection<ICard> AvailableCards => _cards;

        public void Remove(ICard card)
        {
            _cards.Remove(card);
        }
    }
}
