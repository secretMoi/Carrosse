using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Carrosse.Elements
{
    public abstract class RessourceImage : Element
    {
        protected string imageChemin = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName) + @"\ressources\images\";
        protected string nomFichier;
        protected Bitmap image;
        
        public RessourceImage(Point position) : base(position)
        {
            
        }

        protected void ChargeImage()
        {
            image = (Bitmap)Image.FromFile(imageChemin + nomFichier);

            double rapport = (double) image.Height / (double) image.Width;
            
            image = new Bitmap(image, new Size(dimensions.X,(int) (dimensions.X * rapport)));
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
    }
}