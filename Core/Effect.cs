using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Effect
    {
        public Effect()
        {
        }

        public Effect(ChainKind kind)
        {
            Chain = kind;
        }

        public ICollection<ResourceKind> Resources { get; } = new List<ResourceKind>();

        public ICollection<ResourceKind> Discount { get; } = new List<ResourceKind>();

        public ChainKind? Chain { get; set; }

        public int Power { get; set; }

        public int Money { get; set; }

        public int Scores { get; set; }

        public ScienceSymbolKind ScienceSymbol { get; set; }

        public static Effect FromDiscount(ResourceKind kind)
        {
            var effect = new Effect();
            effect.Discount.Add(kind);
            return effect;
        }

        public static Effect FromResource(ResourceKind kind)
        {
            var effect = new Effect();
            effect.Resources.Add(kind);
            return effect;
        }
    }
}
