namespace Miracles.Core
{
    // TODO: implement epoch pattern with card blocking and discovery
    public class Epoch : IEpoch
    {   
        public EpochNumber Number => throw new NotImplementedException();

        public IReadOnlyCollection<Card> AvailableCards => throw new NotImplementedException();

        public void Remove(Card card) => throw new NotImplementedException();
    }
}