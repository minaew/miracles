using System.Collections.Generic;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Tests.Mocks
{
    public class CustomEpochFactory : IEpochFactory
    {
        private readonly IDictionary<EpochNumber, IEpoch> _epochs =
            new Dictionary<EpochNumber, IEpoch>
        {
            { EpochNumber.First, new OneLineEpoch() },
            { EpochNumber.Second, new OneLineEpoch() },
            { EpochNumber.Third, new OneLineEpoch() },
        };

        public IEpoch this[EpochNumber number]
        {
            get { return _epochs[number]; }
            set { _epochs[number] = value; }
        }
    }
}
