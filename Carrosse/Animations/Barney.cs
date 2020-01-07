using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Animations
{
    public class Barney : Animation
    {
        private int ticks;
        public Barney(Point position) : base(position)
        {
            element = new Elements.Personnage(position);
        }

        public override void Anime()
        {
            if (ticks > 5)
            {
                element.Zoom(1.015);
                ticks = 0;
            }

            ticks++;
        }
    }
}