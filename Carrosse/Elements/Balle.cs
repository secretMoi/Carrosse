using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Carrosse.Elements
{
    public class Balle : Element
    {
        private string imageChemin = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName) + @"\ressources\images\balle.png";
        private Bitmap image;

        public Balle(Point position) : base(position)
        {
            dimensions.X = 59;
            dimensions.Y = 164;
            
            image = (Bitmap)Image.FromFile(imageChemin);
            image = new Bitmap(image, new Size(dimensions.X,dimensions.Y));
        }

        public override void Affiche(Graphics graphics)
        {
            graphics.DrawImage(image, position);
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
        
        public override string ToString()
        {
            return "Balle";
        }
    }
}