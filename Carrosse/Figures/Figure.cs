using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Carrosse.Figures
{
    public abstract class Figure
    {
        protected Point position;
        protected Point dimension;
        protected Color CouleurRemplissage;
        protected Color CouleurContour;
        protected int largeurContour;
        
        protected Bitmap image;
        protected Graphics Graphique;
        protected SolidBrush Remplissage;
        protected Pen Contour;

        public Figure(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0)
        {
            this.position = position;
            this.dimension = dimension;
            
            this.CouleurRemplissage = couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color) contour;
            this.largeurContour = largeurContour;
            
            image = new Bitmap(this.dimension.X, this.dimension.Y);
            Graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected virtual void Genere()
        {
            Remplissage = new SolidBrush(CouleurRemplissage);
            Contour = new Pen(CouleurContour, largeurContour);
        }
        
        public void Rotation(float angle)
        {
            int largeurImage, hauteurImage, x, y;
            var dW = (double)image.Width;
            var dH = (double)image.Height;

            double degrees = Math.Abs(angle);
            
            if (degrees <= 90)
            {
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                largeurImage = (int)(dH * dSin + dW * dCos);
                hauteurImage = (int)(dW * dSin + dH * dCos);
                x = (largeurImage - image.Width) / 2;
                y = (hauteurImage - image.Height) / 2;
            }
            else
            {
                degrees -= 90;
                double radians = 0.0174532925 * degrees;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                largeurImage = (int)(dW * dSin + dH * dCos);
                hauteurImage = (int)(dH * dSin + dW * dCos);
                x = (largeurImage - image.Width) / 2;
                y = (hauteurImage - image.Height) / 2;
            }

            var rotateAtX = image.Width / 2f;
            var rotateAtY = image.Height / 2f;

            var bmpRet = new Bitmap(largeurImage, hauteurImage);
            bmpRet.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (var graphics = Graphics.FromImage(bmpRet))
            {
                graphics.TranslateTransform(rotateAtX + x, rotateAtY + y);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-rotateAtX - x, -rotateAtY - y);
                graphics.DrawImage(image, new PointF(0 + x, 0 + y));
            }

            image = bmpRet;
        }

        public Point Dimension => dimension;
        public Bitmap Image => image;
        public Point Position => position;

        public void SetPositionX(int positionX)
        {
            position.X = positionX;
        }
        
        public void SetPositionY(int positionY)
        {
            position.Y = positionY;
        }
    }
}