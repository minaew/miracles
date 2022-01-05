namespace Miracles.Core
{
    public interface IEpoch
    {
        EpochNumber Number { get; }

        IReadOnlyCollection<Card> AvailableCards { get; }

        void Remove(Card card);
    }
}
