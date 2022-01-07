using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Cost
    {
        public int Money { get; set; }

        public ICollection<ResourceKind> Resources { get; } = new List<ResourceKind>();
    }
}
