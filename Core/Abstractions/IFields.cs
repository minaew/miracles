using System;
using Miracles.Core.Enums;

namespace Miracles.Core.Abstractions
{
    public interface IField
    {
        Player? Winner { get; }

        /// <summary>
        /// Add military power for player
        /// </summary>
        /// <returns>Amount of money loss for opponent</returns>
        int Add(Player player, int power);

        Tuple<Player, int> Scores { get; }
    }
}
