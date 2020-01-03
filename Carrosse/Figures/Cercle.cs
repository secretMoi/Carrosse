using System.Drawing;

namespace Carrosse.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Point position, int rayon, Color contour, int largeurContour) :
            base(position, new Point(rayon, rayon), null, contour, largeurContour)
        {
        }

        public override void Genere()
        {
            int rayon = dimension.X;

            Graphique.DrawEllipse(Contour,
                position.X, position.Y,
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}