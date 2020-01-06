using System.Drawing;

namespace Carrosse.Animations
{
    public class Cible : Animation
    {
        public Cible(Point position) : base(position)
        {
            element = new Elements.Cible(position);
        }
        public override void Anime()
        {
            
        }
    }
}