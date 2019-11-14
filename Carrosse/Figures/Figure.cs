using System.Drawing;

namespace Carrosse.Figures
{
    public abstract class Figure
    {
        protected Point position;
        protected Point dimension;
        protected Color couleur;
        
        protected Bitmap image;
        protected Graphics graphique;
        protected Pen pinceau;

        public Bitmap Image => image;

        public Point Position => position;

        public Figure(Point position, Point dimension, Color couleur)
        {
            this.position = position;
            this.dimension = dimension;
            this.couleur = couleur;
            
            image = new Bitmap(this.dimension.X, this.dimension.Y);
            graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected abstract void Genere();

        public virtual void Deplace()
        {
            
        }
    }
}