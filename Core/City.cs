using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class City : ICity
    {
        private int _money;
        private readonly List<Card> _cards = new List<Card>();
        private readonly IDictionary<Wonder, bool> _wonders = new Dictionary<Wonder, bool>();

        public IReadOnlyCollection<Wonder> AvailableWonders => _wonders
            .Where(w => w.Value).Select(w => w.Key).ToList();

        public bool CanBuild(Card card)
        {
            if (card is null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            var resource = _cards.Select(c => c.Effect.Resource).Aggregate(new Resource(), (r1, r2) => r1 + r2);
            // TODO: implement other ways
            // 0. Resource from wonders
            // 1. buy Resource
            // 2, build chain
            return resource.Covers(card.Cost.Resource);
        }

        public bool Build(Card card)
        {
            if (CanBuild(card))
            {
                _cards.Add(card);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Trash()
        {
            _money += 2 + _cards.Count(c => c.Color == CardColor.Yellow);
        }

        public bool CanBuild(Wonder wonder)
        {
            if (wonder is null)
            {
                throw new ArgumentNullException(nameof(wonder));
            }

            if (_wonders[wonder]) return true; // already built

            var Resource = _cards.Select(c => c.Effect.Resource).Aggregate((r1, r2) => r1 + r2);
            // TODO: implement other ways
            // 0. Resource from wonders
            // 1. buy Resource
            return Resource.Covers(wonder.Cost.Resource);
        }

        public bool Build(Wonder wonder)
        {
            if (CanBuild(wonder))
            {
                _wonders[wonder] = true;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
