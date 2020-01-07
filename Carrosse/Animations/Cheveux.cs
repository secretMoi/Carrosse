using System.Drawing;

namespace Carrosse.Animations
{
    public class Cheveux : Animation
    {
        public Cheveux(Point position) : base(position)
        {
            element = new Elements.Cheveux(position);
        }
        public override void Anime()
        {
            
        }
    }
}