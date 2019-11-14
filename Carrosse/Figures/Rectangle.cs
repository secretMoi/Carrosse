using System.Drawing;

namespace Carrosse.Figures
{
    public class Rectangle : Figure
    {
        public Rectangle(Point position, Point dimension, Color couleur) : base(position, dimension, couleur)
        {
        }

        protected override void Genere()
        {
            int brosse = dimension.X;
            if (dimension.X < dimension.Y)
                brosse = dimension.Y;
            
            pinceau = new Pen(couleur, brosse);
            
            graphique.DrawRectangle(pinceau,
                0, 0, 
                dimension.X, dimension.Y); // dessine le rectangle dans l'image
        }
    }
}