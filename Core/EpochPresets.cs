using System.Collections.Generic;
using Miracles.Core.Enums;

namespace Miracles.Core
{
    internal static class EpochPresets
    {
        public static IReadOnlyCollection<Card> First { get; } = new List<Card>
        {
            new Card("лесоповал",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Wood)),
            new Card("лесозаготовки",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Wood),
                     new Cost(1)),
            new Card("глиняный карьер",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Brick)),
            new Card("карьер",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Brick),
                     new Cost(1)),
            new Card("каменоломня",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Stone)),
            new Card("каменный карьер",
                     CardColor.Brown,
                     Effect.FromResource(ResourceKind.Stone),
                     new Cost(1)),

            new Card("стекольная мастерская",
                     CardColor.Gray,
                     Effect.FromResource(ResourceKind.Glass),
                     new Cost(1)),
            new Card("папирусная мастерская",
                     CardColor.Gray,
                     Effect.FromDiscount(ResourceKind.Paper),
                     new Cost(1)),

            new Card("сторожевая вышка",
                     CardColor.Red,
                     new Effect { Power = 1 }),
            new Card("конюшня",
                     CardColor.Red,
                     new Effect(ChainKind.Stables) { Power = 1 },
                     new Cost(ResourceKind.Wood)),
            new Card("гарнизон",
                     CardColor.Red,
                     new Effect(ChainKind.Garrison) { Power = 1 },
                     new Cost(ResourceKind.Brick)),
            new Card("частокол",
                     CardColor.Red,
                     new Effect { Power = 1 },
                     new Cost(2)),

            new Card("мастерская",
                     CardColor.Green,
                     new Effect(), // TODO
                     new Cost(ResourceKind.Paper)),
            new Card("аптека",
                     CardColor.Green,
                     new Effect(), // TODO
                     new Cost(ResourceKind.Glass)),
            new Card("скрипторий",
                     CardColor.Green,
                     new Effect(ChainKind.Book), // TODO
                     new Cost(2)),
            new Card("лавка травника",
                     CardColor.Green,
                     new Effect(ChainKind.Gear), // TODO
                     new Cost(2)),

            new Card("склад камней",
                     CardColor.Yellow,
                     Effect.FromDiscount(ResourceKind.Stone),
                     new Cost(3)),
            new Card("склад глины",
                     CardColor.Yellow,
                     Effect.FromDiscount(ResourceKind.Brick),
                     new Cost(3)),
            new Card("склад древесины",
                     CardColor.Yellow,
                     Effect.FromDiscount(ResourceKind.Wood),
                     new Cost(3)),
            new Card("таверна",
                     CardColor.Yellow,
                     new Effect(ChainKind.Jug)), // TODO

            new Card("театр",
                     CardColor.Blue,
                     new Effect(ChainKind.Mask)), // TODO
            new Card("алтарь",
                     CardColor.Blue,
                     new Effect(ChainKind.Moon)), // TODO
            new Card("бани",
                     CardColor.Blue,
                     new Effect(ChainKind.Drop),  // TODO
                     new Cost(ResourceKind.Stone))
        };
    }
}
