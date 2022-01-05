using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Effect
    {
        public Resource Resource { get; set; } = new Resource();

        public ResourceKind? Discount { get; set; }
    }
}
