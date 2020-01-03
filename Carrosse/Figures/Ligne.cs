using System.Drawing;

namespace Carrosse.Figures
{
    public class Ligne : Figure
    {
        public Ligne(Point positionSource, Point positionDestination, Color contour, int largeurContour) : 
            base(positionSource, positionDestination, null, contour, largeurContour)
        {
        }

        // on doit overrider Deplace sinon seul le premier point bouge vu que le 2è est associé aux dimensions 
        public override void Deplace(int x, int y)
        {
            Point anciennePosition = position;
            base.Deplace(x, y);

            dimension.X -= anciennePosition.X - position.X;
            dimension.Y -= anciennePosition.Y - position.Y;
        }

        public override void Genere()
        {
            Graphique.DrawLine(Contour,
                position.X, position.Y,
                dimension.X, dimension.Y); // dessine la ligne
        }
    }
}