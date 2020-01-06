using System.Drawing;

namespace Carrosse.Animations
{
    public class Barney : Animation
    {
        public Barney(Point position) : base(position)
        {
            element = new Elements.Personnage(position);
        }
        public override void Anime()
        {
            
        }
    }
}