using System;
using System.Collections.Generic;
using Miracles.Core.Abstractions;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    public class Field : IField
    {
        private int _balance;
        private readonly Dictionary<Player, bool[]> _history = new()
        {
            { Player.First,  new [] { true, true } },
            { Player.Second, new [] { true, true } },
        };

        public Player? Winner { get; private set; }

        public Tuple<Player, int> Scores
        {
            get
            {
                var player = _balance > 0 ? Player.First : Player.Second;
                int scores = (_balance > 0 ? _balance : - _balance) switch
                {
                    0 => 0,
                    1 => 2,
                    2 => 2,
                    3 => 5,
                    4 => 5,
                    5 => 5,
                    _ => 10,
                };

                return Tuple.Create(player, scores);
            }
        }

        public int Add(Player player, int power)
        {
            // move marker
            switch (player)
            {
                case Player.First:
                    _balance += power;
                    break;

                case Player.Second:
                    _balance -= power;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(player));
            }

            // check for victory
            if (_balance >= 9)
            {
                Winner = Player.First;
                return 0;
            }
            if (_balance < -9)
            {
                Winner = Player.Second;
                return 0;
            }

            switch (_balance > 0 ? _balance : - _balance)
            {
                case 3:
                case 4:
                case 5:
                    if (_history[Player.Second][0])
                    {
                        _history[Player.Second][0] = false;
                        return 2;
                    }
                    break;

                case 6:
                case 7:
                case 8:
                    if (_history[Player.Second][1])
                    {
                        _history[Player.Second][1] = false;
                        return 5;
                    }
                    break;
            }

            return 0;
        }
    }
}
