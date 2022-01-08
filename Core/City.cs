using System;
using System.Collections.Generic;
using System.Linq;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;
using Miracles.Core.Helpers;

namespace Miracles.Core
{
    public sealed class City : ICity, IResourceCostCalculator
    {
        private readonly List<ICard> _cards = new();
        private readonly Dictionary<Wonder, bool> _wonders = new();

        private City() // FIXME: ResourceCostCalculator
        {
        }

        public static Tuple<City, City> CreatePair() // FIXME: ResourceCostCalculator
        {
            var city1 = new City();
            var city2 = new City();
            city1.ResourceCostCalculator = city2;
            city2.ResourceCostCalculator = city1;

            return Tuple.Create(city1, city2);
        }

        public IReadOnlyCollection<Wonder> AvailableWonders => _wonders
            .Where(w => w.Value).Select(w => w.Key).ToList();

        public int Money { get; set; }

        public IResourceCostCalculator ResourceCostCalculator { get; set; }

        public bool CanBuild(ICostable costable)
        {
            if (costable is null)
            {
                throw new ArgumentNullException(nameof(costable));
            }

            if (costable.Cost.Chain.HasValue)
            {
                var chain = costable.Cost.Chain.Value;
                var chains = _cards.Select(c => c.Effect.Chain)
                                   .Where(c => c != null)
                                   .Cast<ChainKind>();
                if (chains.Contains(chain))
                {
                    return true;
                }
            }

            var cityResources = _cards.SelectMany(c => c.Effect.Resources);
            var discounts = _cards.SelectMany(c => c.Effect.Discount);
            var resourcesToBuy = costable.Cost.Resources.Except(cityResources);

            var cost = costable.Cost.Money;
            foreach (var resource in resourcesToBuy)
            {
                if (discounts.Contains(resource))
                {
                    cost++;
                }
                else
                {
                    cost += ResourceCostCalculator.GetCost(resource);
                }
            }

            return Money >= cost;
        }

        public bool Build(ICard card)
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

        public int GetCost(ResourceKind kind) =>
            2 + _cards.Where(c => c.Color == CardColor.Brown ||
                                  c.Color == CardColor.Gray)
                      .SelectMany(c => c.Effect.Resources)
                      .Count(r => r == kind);

        public void Loot(int money)
        {
            Money -= money;
            if (Money < 0)
            {
                Money = 0;
            }
        }
    }
}
