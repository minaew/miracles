using Miracles.Core.Abstractions;

namespace Miracles.Core
{
    public class Wonder : ICostable
    {
        public Cost Cost { get; set; } = new Cost(0);

        public Effect Effect { get; set; } = new Effect();
    }
}
