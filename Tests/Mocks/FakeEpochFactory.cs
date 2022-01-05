using System.Collections.Generic;
using Miracles.Core;

namespace Miracles.Tests.Mocks
{
    public class CustomEpochFactory : IEpochFactory
    {
        private readonly IDictionary<EpochNumber, IEpoch> _epochs =
            new Dictionary<EpochNumber, IEpoch>
        {
            { EpochNumber.First, new OneLineEpoch(EpochNumber.First) },
            { EpochNumber.Second, new OneLineEpoch(EpochNumber.Second) },
            { EpochNumber.Third, new OneLineEpoch(EpochNumber.Third) },
        };

        public IEpoch this[EpochNumber number]
        {
            get { return _epochs[number]; }
            set { _epochs[number] = value; }
        }
    }
}
