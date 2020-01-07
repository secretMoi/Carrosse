using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Animations
{
    public class Barney : Animation
    {
        private int ticks;
        private bool animationActive;
        public Barney(Point position) : base(position)
        {
            animationActive = true;
            element = new Elements.Personnage(position);
        }

        public override void Hydrate(params object[] parametre)
        {
            animationActive = (bool)parametre[0];
        }

        public override void Anime()
        {
            if(!animationActive) return;
            
            if (ticks > 7)
            {
                element.Zoom(1);
                ticks = 0;
            }

            ticks++;
        }
    }
}