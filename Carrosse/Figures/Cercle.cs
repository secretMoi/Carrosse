using System.Drawing;

namespace Carrosse.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Point position, int rayon, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) :
            base(position, new Point(rayon, rayon), couleurRemplissage, contour, largeurContour)
        {
            image = new Bitmap(rayon * 2, rayon * 2);
            Graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected override void Genere()
        {
            base.Genere();
            
            int rayon = dimension.X;
            
            Graphique.FillEllipse(Remplissage,largeurContour, largeurContour, 
                dimension.X, dimension.Y);
            
            Graphique.DrawEllipse(Contour,
                largeurContour, largeurContour, 
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}