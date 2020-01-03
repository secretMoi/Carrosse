using System.Drawing;

namespace Carrosse.Figures
{
    public class Disque : Figure
    {
        public Disque(Point position, int rayon, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) :
            base(position, new Point(rayon, rayon), couleurRemplissage, contour, largeurContour)
        {
        }

        public override void Genere()
        {
            int rayon = dimension.X;
            
            Graphique.FillEllipse(Remplissage, position.X, position.Y, 
                dimension.X, dimension.Y);
            
            Graphique.DrawEllipse(Contour,
                position.X, position.Y,
                rayon, rayon); // dessine le disque dans l'image
        }
    }
}