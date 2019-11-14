using System.Drawing;

namespace Carrosse.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Point position, int rayon, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) :
            base(position, new Point(rayon, rayon), couleurRemplissage, contour, largeurContour)
        {
            image = new Bitmap(rayon * 2, rayon * 2);
            graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected override void Genere()
        {
            base.Genere();
            
            int rayon = dimension.X;
            
            graphique.DrawEllipse(contour,
                rayon / 2, rayon / 2, 
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}