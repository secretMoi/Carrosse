using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carrosse.Figures
{
    public abstract class Figure
    {
        protected Point position;
        protected Point dimension;
        protected Rotation rotation;
        protected Color CouleurRemplissage;
        protected Color CouleurContour;
        protected int largeurContour;
        
        protected Bitmap image;
        protected static PictureBox pictureBox;
        protected static Graphics GraphiquePartage;
        protected Graphics Graphique;
        protected SolidBrush Remplissage;
        protected Pen Contour;

        public Figure(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0)
        {
            this.position = position;
            this.dimension = dimension;
            
            rotation = new Rotation();
            
            this.CouleurRemplissage = couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color) contour;
            this.largeurContour = largeurContour;

            Graphique = GraphiquePartage;

            //int dimensionMax = PlusGrand(this.dimension.X, this.dimension.Y);
            
            /*image = new Bitmap(dimensionMax, dimensionMax);
            Graphique = Graphics.FromImage(image);*/
            
            Genere();
        }

        public static void InitialiseConteneur(PictureBox pictureBox)
        {
            Figure.pictureBox = pictureBox;
            Figure.GraphiquePartage = Graphics.FromHwnd(Figure.pictureBox.Handle);
        }

        protected int PlusGrand(int nombre1, int nombre2)
        {
            if (nombre1 > nombre2)
                return nombre1;

            return nombre2;
        }

        public void Afficher(Graphics graphics)
        {
            Genere(graphics);
        }

        public abstract void Genere(Graphics graphics = null);

        protected void PreparationAffichage(Graphics graphics = null)
        {
            if(Remplissage == null)
                Remplissage = new SolidBrush(CouleurRemplissage);
            if(Contour == null)
                Contour = new Pen(CouleurContour, largeurContour);
            
            if (graphics != null)
                Graphique = graphics;
        }
        
        /*public void Rotation2(double angle)
        {
            int largeur = Image.Width;
            int hauteur = Image.Height;

            angle = 360 - angle;
            
            //create a new empty bitmap to hold rotated image
            Bitmap imageDestination = new Bitmap(largeur, hauteur);
            //make a graphics object from the empty bitmap
            using(Graphics g = Graphics.FromImage(imageDestination)) 
            {
                //move rotation point to center of image
                g.TranslateTransform(0, 0);
                //rotate
                g.RotateTransform((float) angle);
                //move image back
                g.TranslateTransform(0, 0);
                //draw passed in image onto graphics object
                g.DrawImage(image, new Point(0, 0)); 
            }

            image = imageDestination;
        }
        
        public void Rotation3(double angle)
        {
            int maxside = (int)(Math.Sqrt(image.Width * image.Width + image.Height * image.Height));
        }
        
        public void Rotation(float angle)
        {
            int largeurImage, hauteurImage, x, y;
            var dW = (double)image.Width;
            var dH = (double)image.Height;

            double degres = Math.Abs(angle);
            
            if (degres <= 90)
            {
                double radians = 0.0174532925 * degres;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                largeurImage = (int)(dH * dSin + dW * dCos);
                hauteurImage = (int)(dW * dSin + dH * dCos);
                x = (largeurImage - image.Width) / 2;
                y = (hauteurImage - image.Height) / 2;
            }
            else
            {
                degres -= 90;
                double radians = 0.0174532925 * degres;
                double dSin = Math.Sin(radians);
                double dCos = Math.Cos(radians);
                largeurImage = (int)(dW * dSin + dH * dCos);
                hauteurImage = (int)(dH * dSin + dW * dCos);
                x = (largeurImage - image.Width) / 2;
                y = (hauteurImage - image.Height) / 2;
            }

            float rotateAtX = image.Width / 2f;
            float rotateAtY = image.Height / 2f;

            Bitmap imageTemp = new Bitmap(largeurImage, hauteurImage);
            imageTemp.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(imageTemp))
            {
                graphics.TranslateTransform(rotateAtX + x, rotateAtY + y);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-rotateAtX - x, -rotateAtY - y);
                graphics.DrawImage(image, new PointF(0 + x, 0 + y));
            }

            image = imageTemp;
        }*/

        public Point Dimension => dimension;

        public Bitmap Image
        {
            get
            {
                int dimensionMax = PlusGrand(dimension.X, dimension.Y);
                //Bitmap images = new Bitmap(dimensionMax, dimensionMax);
                //Graphique = Graphics.FromImage(images);

                return new Bitmap(dimensionMax,dimensionMax, GraphiquePartage);
            }
        }
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