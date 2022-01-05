using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class City : ICity
    {
        private readonly List<Card> _cards = new List<Card>();
        private readonly IDictionary<Wonder, bool> _wonders = new Dictionary<Wonder, bool>();

        public IReadOnlyCollection<Wonder> AvailableWonders => _wonders
            .Where(w => w.Value).Select(w => w.Key).ToList();

        public int Money { get; set; }

        public bool CanBuild(ICostable costable)
        {
            if (costable is null)
            {
                throw new ArgumentNullException(nameof(costable));
            }

            var resource = _cards.Select(c => c.Effect.Resource)
                                 .Aggregate(new Resource(), (r1, r2) => r1 + r2);

            if (resource.Covers(costable.Cost.Resource))
            {
                return true;
            }

            var lack = costable.Cost.Resource - resource;

            var discounts = _cards.Select(c => c.Effect.Discount)
                                  .Where(d => d.HasValue)
                                  .Select(d => d.Value)
                                  .Distinct();


            var resourceCost = 0;
            if (lack.Wood > 0)
            {
                if (discounts.Contains(ResourceKind.Wood))
                {
                    resourceCost += lack.Wood;
                }
            }

            if (lack.Brick > 0)
            {
                if (discounts.Contains(ResourceKind.Brick))
                {
                    resourceCost += lack.Brick;
                }
            }

            if (lack.Stone > 0)
            {
                if (discounts.Contains(ResourceKind.Stone))
                {
                    resourceCost += lack.Stone;
                }
            }

            if (lack.Glass > 0)
            {
                if (discounts.Contains(ResourceKind.Glass))
                {
                    resourceCost += lack.Glass;
                }
            }

            if (lack.Paper > 0)
            {
                if (discounts.Contains(ResourceKind.Paper))
                {
                    resourceCost += lack.Paper;
                }
            }

            if (resourceCost > 0 && resourceCost <= Money)
            {
                return true;
            }

            return false;
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

        public void Trash()
        {
            Money += 2 + _cards.Count(c => c.Color == CardColor.Yellow);
        }
    }
}
