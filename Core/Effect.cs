using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Effect
    {
        public ICollection<ResourceKind> Resources { get; } = new List<ResourceKind>();

        public ICollection<ResourceKind> Discount { get; } = new List<ResourceKind>();
    }
}
