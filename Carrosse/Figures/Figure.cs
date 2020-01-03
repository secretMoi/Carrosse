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
        public double angle;
        protected Color CouleurRemplissage;
        protected Color CouleurContour;
        protected int largeurContour;
        
        protected static Graphics GraphiquePartage;
        protected Graphics Graphique;
        protected SolidBrush Remplissage;
        protected Pen Contour;

        public Figure(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0)
        {
            this.position = position;
            this.dimension = dimension;
            this.angle = 0.0;
            
            rotation = new Rotation();
            
            this.CouleurRemplissage = couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color) contour;
            this.largeurContour = largeurContour;

            Graphique = GraphiquePartage;
            
            Dessine();
        }

        public static void InitialiseConteneur(PictureBox pictureBox)
        {
            GraphiquePartage = Graphics.FromHwnd(pictureBox.Handle);
        }

        protected int PlusGrand(int nombre1, int nombre2)
        {
            if (nombre1 > nombre2)
                return nombre1;

            return nombre2;
        }

        public void Afficher(Graphics graphics)
        {
            Dessine(graphics);
        }

        public abstract void Genere(Graphics graphics = null);

        public void Dessine(Graphics graphics = null)
        {
            PreparationAffichage(graphics);
            
            Genere(graphics);
            
            FinDessin();
        }

        public void FinDessin()
        {
            // permet de rectifier l'angle pour ne pas impacter les autres éléments
            if (Math.Abs(angle) > 1)
            {
                Graphique.TranslateTransform(position.X + dimension.X / 2, position.Y);
                // rotation
                Graphique.RotateTransform(-(float) angle);
                Graphique.TranslateTransform(-(position.X+ dimension.X / 2), -position.Y);
            }
        }

        protected void PreparationAffichage(Graphics graphics = null)
        {
            if(Remplissage == null)
                Remplissage = new SolidBrush(CouleurRemplissage);
            if(Contour == null)
                Contour = new Pen(CouleurContour, largeurContour);
            
            if (graphics != null)
                Graphique = graphics;

            if (Math.Abs(angle) > 1)
            {
                Graphique.FillRectangle(new SolidBrush(Color.Chartreuse), position.X + dimension.X / 2, position.Y, 20, 20);
            
                Graphique.TranslateTransform(position.X + dimension.X / 2, position.Y);
                // rotation
                Graphique.RotateTransform((float) angle);
                Graphique.TranslateTransform(-(position.X+ dimension.X / 2), -position.Y);
            }
        }
        
        public void Rotation(double angle)
        {
            angle = 360 - angle;

            this.angle = angle;
        }
        
        public void Tourne(double angle)
        {
            angle = -angle;

            this.angle += angle;
        }
        
        /*        
        public void Rotation3(double angle)
        {
            int maxside = (int)(Math.Sqrt(image.Width * image.Width + image.Height * image.Height));
        }*/

        public Point Dimension => dimension;
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