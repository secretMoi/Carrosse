using System.Drawing;

namespace Carrosse
{
    public class Bonhomme : Element
    {
        public Bonhomme(Point position) : base(position)
        {
            this.dimensions = new Point(200, 100);
            
            // création corps
            Point dimension = new Point(200, 100);
            AjouterRectangle("corps", position, dimension, Color.Yellow, Color.Firebrick, 3);

            // création fenêtre gauche
            dimension = new Point(40, 30);
            position.X = this.position.X + 10;
            position.Y = this.position.Y + 10;
            AjouterRectangle("fenetreG", position, dimension, Color.Navy);
        }
    }
}