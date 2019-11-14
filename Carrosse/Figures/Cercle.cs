using System.Drawing;

namespace Carrosse.Figures
{
    public class Cercle : Figure
    {
        public Cercle(Point position, int rayon, Color couleur) : base(position, new Point(rayon, rayon), couleur)
        {
            image = new Bitmap(rayon * 2, rayon * 2);
            graphique = Graphics.FromImage(image);
            
            Genere();
        }

        protected override void Genere()
        {
            int rayon = dimension.X;
            pinceau = new Pen(couleur, rayon);
            
            graphique.DrawEllipse(pinceau,
                rayon / 2, rayon / 2, 
                rayon, rayon); // dessine le cercle dans l'image
        }
    }
}