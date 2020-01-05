using System.Drawing;

namespace Carrosse.Animations
{
    public class Tireur : Animation
    {
        public Tireur(Point position) : base(position)
        {
            element = new Elements.Bonhomme(position);
        }

        public void Anime()
        {
            
        }
    }
}