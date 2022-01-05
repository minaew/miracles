namespace Miracles.Core
{
    public class EpochFactory : IEpochFactory
    {
        public IEpoch this[EpochNumber number] => throw new NotImplementedException();
    }
}
