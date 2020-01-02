using System.Drawing;

namespace Carrosse.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Point position, int rayon, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) :
            base(position, new Point(rayon, rayon), couleurRemplissage, contour, largeurContour)
        {
        }

        public override void Genere(Graphics graphics = null)
        {
            PreparationAffichage(graphics);
            
            int rayon = dimension.X;
            
            Graphique.FillEllipse(Remplissage, position.X, position.Y, 
                dimension.X, dimension.Y);
            
            Graphique.DrawEllipse(Contour,
                position.X, position.Y,
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}