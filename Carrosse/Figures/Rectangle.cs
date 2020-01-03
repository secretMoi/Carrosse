using System.Drawing;

namespace Carrosse.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(Point position, Point dimension, Color? remplissage = null, Color? contour = null, int largeurContour = 10) :
            base(position, dimension, remplissage, contour, largeurContour)
        {
            
        }

        public override void Genere()
        {
            Graphique.FillRectangle(Remplissage, position.X, position.Y, 
                dimension.X, dimension.Y);
            
            Graphique.DrawRectangle(Contour,
                position.X, position.Y, 
                dimension.X, dimension.Y); // dessine le rectangle dans l'image
        }
    }
}