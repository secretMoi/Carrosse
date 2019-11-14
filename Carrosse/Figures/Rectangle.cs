using System.Drawing;

namespace Carrosse.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 10) :
            base(position, dimension, remplissage, contour, largeurContour)
        {
            
        }

        protected override void Genere()
        {
            base.Genere();
            
            graphique.FillRectangle(remplissage,0, 0, 
                dimension.X, dimension.Y);
            
            graphique.DrawRectangle(contour,
                0, 0, 
                dimension.X, dimension.Y); // dessine le rectangle dans l'image
        }
    }
}