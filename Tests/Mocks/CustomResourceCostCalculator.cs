using System.Collections.Generic;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Tests.Mocks
{
    public class CustomResourceCostCalculator : Dictionary<ResourceKind, int>,
                                                IResourceCostCalculator
    {
        public int GetCost(ResourceKind kind) => this[kind];
    }
}
