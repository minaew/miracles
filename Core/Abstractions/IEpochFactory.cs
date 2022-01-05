using Miracles.Core.Enums;

namespace Miracles.Core.Abstractions
{
    public interface IEpochFactory
    {
        IEpoch this[EpochNumber number] { get; }
    }
}
