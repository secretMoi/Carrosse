using System.Drawing;

namespace Carrosse.Figures
{
    public class Ellipse : Figure
    {
        public Ellipse(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) : 
            base(position, dimension, couleurRemplissage, contour, largeurContour)
        {
            
        }
        
        public override void Genere()
        {
            Graphique.FillEllipse(Remplissage, position.X, position.Y, 
                dimension.X, dimension.Y);
            
            Graphique.DrawEllipse(Contour,
                position.X, position.Y, 
                dimension.X, dimension.Y); // dessine le cercle dans l'image
        }
    }
}