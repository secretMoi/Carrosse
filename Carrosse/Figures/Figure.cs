using System.Drawing;
using System.Windows.Forms;

namespace Carrosse.Figures
{
    public abstract class Figure
    {
        protected Point position;
        protected Point dimension;
        protected Color couleurRemplissage;
        protected Color couleurContour;
        protected int largeurContour;
        
        protected Bitmap image;
        protected Graphics graphique;
        protected SolidBrush remplissage;
        protected Pen contour;

        public Figure(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0)
        {
            this.position = position;
            this.dimension = dimension;
            
            this.couleurRemplissage = couleurRemplissage;
            if (contour != null)
                this.couleurContour = (Color) contour;
            this.largeurContour = largeurContour;
            
            image = new Bitmap(this.dimension.X, this.dimension.Y);
            graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected virtual void Genere()
        {
            remplissage = new SolidBrush(couleurRemplissage);
            contour = new Pen(couleurContour, largeurContour);
        }

        public Point Dimension => dimension;
        public Bitmap Image => image;

        public Point Position
        {
            get => position;
            set => position = value;
        }
    }
}