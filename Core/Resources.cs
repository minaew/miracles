namespace Miracles.Core
{
    public class Resources
    {
        public int Wood { get; set; }

        public int Brick { get; set; }

        public int Stone { get; set; }

        public int Glass { get; set; }

        public int Paper { get; set; }

        public static Resources operator +(Resources r1, Resources r2)
        {
            return new Resources
            {
                Wood = r1.Wood + r2.Wood,
                Brick = r1.Brick + r2.Brick,
                Stone = r1.Stone + r2.Stone,
                Glass = r1.Glass + r2.Glass,
                Paper = r1.Paper + r2.Paper
            };
        }

        public bool Covers(Resources resources)
        {
            return Wood >= resources.Wood &&
                   Brick >= resources.Brick &&
                   Stone >= resources.Stone &&
                   Glass >= resources.Glass &&
                   Paper >= resources.Paper;
        }
    }
}
