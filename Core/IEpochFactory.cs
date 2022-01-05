namespace Miracles.Core
{
    public interface IEpochFactory
    {
        IEpoch this[EpochNumber number] { get; }
    }
}