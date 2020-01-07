using System.Drawing;

namespace Carrosse.Animations
{
    public class Cible : Animation
    {
        private bool animationActive;
        public Cible(Point position) : base(position)
        {
            element = new Elements.Cible(position);
            animationActive = false;
        }

        public override void Hydrate(params object[] parametre)
        {
            animationActive = (bool)parametre[0];
        }

        public override void Anime()
        {
            if(!animationActive) return;
            
            element.Deplace(1);
        }
    }
}