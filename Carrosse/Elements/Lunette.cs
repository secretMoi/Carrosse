using System.Drawing;

namespace Carrosse.Elements
{
    public class Lunette : Element
    {
        public Lunette(Point positionConstrcuteur) : base(positionConstrcuteur)
        {
            // création cercle lunette
            dimensionFigure = new Point(400, 400);
            dimensions = dimensionFigure;
            AjouterCercle("lunette", Color.Black, 15);
            
            // création mollette gauche
            dimensionFigure = new Point(50, 100);
            position.X -= dimensionFigure.X;
            position.Y += elements["lunette"].Dimension.Y / 2
                          - dimensionFigure.X;
            AjouterRectangle("molletteG", Color.Black);
            
            // création mollette droite
            dimensionFigure = new Point(50, 100);
            position.X += elements["lunette"].Dimension.X
                          + dimensionFigure.X;
            AjouterRectangle("molletteD", Color.Black);
            
            // création mollette haut
            dimensionFigure = new Point(100, 50);
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2
                         - dimensionFigure.X / 2;
            position.Y = elements["lunette"].Position.Y
                          - dimensionFigure.Y;
            AjouterRectangle("molletteH", Color.Black);
            
            // création ligne verticale
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2;
            position.Y = elements["lunette"].Position.Y;
            dimensionFigure.X = position.X;
            dimensionFigure.Y = position.Y + elements["lunette"].Dimension.Y;
            AjouterLigne("ligneVerticale", Color.Black, 2);
            
            // création ligne horizontale
            position.X = elements["lunette"].Position.X;
            position.Y = elements["lunette"].Position.Y
                         + elements["lunette"].Dimension.Y / 2;
            dimensionFigure.X = position.X + elements["lunette"].Dimension.X;
            dimensionFigure.Y = position.Y;
            AjouterLigne("ligneHorizontale", Color.Black, 2);
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
        
        public override string ToString()
        {
            return "Lunette";
        }
    }
}