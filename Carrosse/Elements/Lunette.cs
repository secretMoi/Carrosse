using System.Drawing;

namespace Carrosse.Elements
{
    public class Lunette : Element
    {
        public Lunette(Point positionConstrcuteur) : base(positionConstrcuteur)
        {
            // création cercle lunette
            dimensions = new Point(400, 400);
            AjouterCercle("lunette", Color.Black, 15);
            
            
            
            // création mollette gauche
            dimensions = new Point(50, 100);
            position.X -= dimensions.X;
            position.Y += elements["lunette"].Dimension.Y / 2
                          - dimensions.X;
            AjouterRectangle("molletteG", Color.Black);
            
            // création mollette droite
            dimensions = new Point(50, 100);
            position.X += elements["lunette"].Dimension.X
                          + dimensions.X;
            AjouterRectangle("molletteD", Color.Black);
            
            // création mollette haut
            dimensions = new Point(100, 50);
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2
                         - dimensions.X / 2;
            position.Y = elements["lunette"].Position.Y
                          - dimensions.Y;
            AjouterRectangle("molletteH", Color.Black);
            
            // création ligne verticale
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2;
            position.Y = elements["lunette"].Position.Y;
            dimensions.X = position.X;
            dimensions.Y = position.Y + elements["lunette"].Dimension.Y;
            AjouterLigne("ligneVerticale", Color.Black, 2);
            
            // création ligne horizontale
            position.X = elements["lunette"].Position.X;
            position.Y = elements["lunette"].Position.Y
                         + elements["lunette"].Dimension.Y / 2;
            dimensions.X = position.X + elements["lunette"].Dimension.X;
            dimensions.Y = position.Y;
            AjouterLigne("ligneHorizontale", Color.Black, 2);
        }

        public void CercleLunetteInterieur()
        {
            dimensions.X = elements["lunette"].Dimension.X / 2;
            dimensions.Y = elements["lunette"].Dimension.Y / 2;
        }
    }
}