using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    // TODO: implement
    public class EpochFactory : IEpochFactory
    {
        public IEpoch this[EpochNumber number] => new Epoch();
    }
}
