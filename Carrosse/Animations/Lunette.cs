using System.Drawing;

namespace Carrosse.Animations
{
    public class Lunette : Animation
    {
        public Lunette(Point position) : base(position)
        {
            element = new Elements.Lunette(position);
        }
        public override void Anime()
        {
            
        }
    }
}