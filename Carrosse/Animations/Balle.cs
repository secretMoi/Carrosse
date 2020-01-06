using System.Drawing;

namespace Carrosse.Animations
{
    public class Balle : Animation
    {
        public Balle(Point position) : base(position)
        {
            element = new Elements.Balle(position);
        }
        public override void Anime()
        {
            
        }
    }
}