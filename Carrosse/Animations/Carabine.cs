using System.Drawing;

namespace Carrosse.Animations
{
    public class Carabine : Animation
    {
        public Carabine(Point position) : base(position)
        {
            element = new Elements.Carabine(position);
        }

        public override void Anime()
        {
        }
    }
}