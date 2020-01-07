using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Carrosse.Elements
{
    public abstract class RessourceImage : Element
    {
        protected string imageChemin = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName) + @"\ressources\images\";
        protected string nomFichier;
        protected Bitmap image;
        private object cadenas = new object();
        
        public RessourceImage(Point position) : base(position)
        {
            elements.Add("Image", null);
        }

        public override void Zoom(double zoom)
        {
            lock (cadenas)
            {
                SizeF ancienneDimensions = image.PhysicalDimension;
                
                image = (Bitmap)Image.FromFile(imageChemin + nomFichier);
                image = new Bitmap(image,
                    new Size((int) (ancienneDimensions.Width * zoom), (int) (ancienneDimensions.Height * zoom)));
            }
        }

        protected void ChargeImage()
        {
            image = (Bitmap)Image.FromFile(imageChemin + nomFichier);

            double rapport = (double) image.Height / (double) image.Width;
            
            image = new Bitmap(image, new Size(dimensions.X,(int) (dimensions.X * rapport)));
        }
        
        public override void Affiche(Graphics graphics)
        {
            lock (cadenas)
            {
                graphics.DrawImage(image, position);
            }
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
    }
}