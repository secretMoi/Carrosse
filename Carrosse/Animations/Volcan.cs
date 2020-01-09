using System.Drawing;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Volcan : Animation
    {
        public Volcan(Point position) : base(position)
        {
            element = new Elements.Volcan(position);
        }

        public override void Anime()
        {
            
        }
    }
}