using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Cost
    {
        public Cost(int money)
        {
            Money = money;
        }

        public Cost(ResourceKind kind)
        {
            Resources.Add(kind);
        }

        public int Money { get; set; }

        public ICollection<ResourceKind> Resources { get; } = new List<ResourceKind>();

        public ChainKind? Chain { get; set; }
    }
}
