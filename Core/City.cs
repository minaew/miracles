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

            var totalResources = _cards.Select(c => c.Effect.Resource).Sum();

            var lack = costable.Cost.Resource - totalResources;

            var discounts = _cards.Select(c => c.Effect.Discount)
                                  .Where(d => d != null)
                                  .Cast<ResourceKind>()
                                  .Distinct()
                                  .ToList();


            var resourceCost = 0;
            foreach (var kind in Enum.GetValues<ResourceKind>())
            {
                if (lack[kind] > 0)
                {
                    if (discounts.Contains(kind))
                    {
                        resourceCost += lack[kind];
                    }
                    else
                    {
                        return false; // cant buy resource
                    }
                }
            }
            if (resourceCost <= Money)
            {
                return true; // enough money for buying
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
