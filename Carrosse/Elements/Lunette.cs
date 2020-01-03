using System.Drawing;

namespace Carrosse.Elements
{
    public class Lunette : Element
    {
        public Lunette(Point position) : base(position)
        {
            // création cercle lunette
            Point dimension = new Point(400, 400);
            AjouterCercle("lunette", position, dimension, Color.Black, 15);
            
            // création mollette gauche
            dimension = new Point(50, 100);
            position.X -= dimension.X;
            position.Y += elements["lunette"].Dimension.Y / 2
                          - dimension.X;
            AjouterRectangle("molletteG", position, dimension, Color.Black);
            
            // création mollette droite
            position.X += elements["lunette"].Dimension.X
                          + dimension.X;
            AjouterRectangle("molletteD", position, dimension, Color.Black);
            
            // création mollette haut
            dimension = new Point(100, 50);
            position.X = elements["lunette"].Dimension.X / 2
                          - dimension.X / 2;
            position.Y = elements["lunette"].Position.Y
                          - dimension.Y;
            AjouterRectangle("molletteH", position, dimension, Color.Black);
            
            // création ligne verticale
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2;
            position.Y = elements["lunette"].Position.Y;
            dimension.X = position.X;
            dimension.Y = position.Y + elements["lunette"].Dimension.Y;
            AjouterLigne("ligneVerticale", position, dimension, Color.Black, 2);
            
            // création ligne horizontale
            position.X = elements["lunette"].Position.X;
            position.Y = elements["lunette"].Position.Y
                         + elements["lunette"].Dimension.Y / 2;
            dimension.X = position.X + elements["lunette"].Dimension.X;
            dimension.Y = position.Y;
            AjouterLigne("ligneHorizontale", position, dimension, Color.Black, 2);
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