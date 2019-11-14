using System.Drawing;
using System.Windows.Forms;

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