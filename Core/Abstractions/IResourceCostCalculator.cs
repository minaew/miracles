using Miracles.Core.Enums;

namespace Miracles.Core.Abstractions
{
    public interface IResourceCostCalculator
    {
        int GetCost(ResourceKind kind);
    }
}
