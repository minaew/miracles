using System;

namespace Miracles.Core
{
    public class Resource
    {
        public int Wood { get; set; }

        public int Brick { get; set; }

        public int Stone { get; set; }

        public int Glass { get; set; }

        public int Paper { get; set; }

        public static Resource operator +(Resource r1, Resource r2)
        {
            if (r1 is null)
            {
                throw new ArgumentNullException(nameof(r1));
            }

            if (r2 is null)
            {
                throw new ArgumentNullException(nameof(r2));
            }

            return new Resource
            {
                Wood = r1.Wood + r2.Wood,
                Brick = r1.Brick + r2.Brick,
                Stone = r1.Stone + r2.Stone,
                Glass = r1.Glass + r2.Glass,
                Paper = r1.Paper + r2.Paper
            };
        }

        public bool Covers(Resource r)
        {
            if (r is null)
            {
                throw new ArgumentNullException(nameof(r));
            }

            return Wood >= r.Wood &&
                   Brick >= r.Brick &&
                   Stone >= r.Stone &&
                   Glass >= r.Glass &&
                   Paper >= r.Paper;
        }

        public static Resource Add(Resource r1, Resource r2)
        {
            return r1 + r2;
        }
    }
}
