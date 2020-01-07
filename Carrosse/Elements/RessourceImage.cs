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
                Bitmap imageTemp;
                
                imageTemp = (Bitmap)Image.FromFile(imageChemin + nomFichier);
                image.Dispose();
                image = new Bitmap(imageTemp,
                    new Size((int) (ancienneDimensions.Width + zoom), (int) (ancienneDimensions.Height + zoom)));
                imageTemp.Dispose();
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
    }
}