using System.Drawing;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class EffetBalle : Animation
    {
        public EffetBalle(Point position = default) : base(position)
        {
            element = new RayonsCentre(position);
        }

        public override void Hydrate(params object[] parametre)
        {
            position.X = (int) parametre[0];
            position.Y = (int) parametre[1];
            element.Deplace(position);
        }

        public override void Anime()
        {
            element.GetFigure("Ligne0").Rotation.Tourne(0.1);
        }
    }
}