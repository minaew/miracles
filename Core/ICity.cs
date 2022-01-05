namespace Miracles.Core
{
    public interface ICity
    {
        IReadOnlyCollection<Wonder> AvailableWonders { get; }

        bool CanBuild(Card card);

        bool Build(Card card);

        bool CanBuild(Wonder wonder);

        bool Build(Wonder wonder);

        void Trash();
    }
}