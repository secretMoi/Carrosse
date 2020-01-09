using System.Drawing;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Kepi : Animation
    {
        public Kepi(Point position) : base(position)
        {
            element = new Chapeau(position);
        }

        public override void Anime()
        {
            
        }
    }
}