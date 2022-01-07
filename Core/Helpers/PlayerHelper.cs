using Miracles.Core.Enums;

namespace Miracles.Core.Helpers
{
    public static class PlayerHelper
    {
        public static Player Other(this Player player)
        {
            return player == Player.First ? Player.Second : Player.First;
        }
    }
}
