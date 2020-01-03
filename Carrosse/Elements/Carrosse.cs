using System.Drawing;

namespace Carrosse.Elements
{
    public class Carrosse : Element
    {
        private static int compteur;
        public Carrosse(Point position) : base(position)
        {
            this.dimensions = new Point(200, 100);
            
            // création corps
            Point dimension = new Point(200, 100);
            AjouterRectangle("corps", position, dimension, Color.Yellow, Color.Firebrick, 3);

            // création fenêtre gauche
            dimension = new Point(40, 30);
            position.X = this.position.X + 10;
            position.Y = this.position.Y + 10;
            AjouterRectangle("fenetreG", position, dimension, Color.Navy, Color.Black, 2);
            
            // création fenêtre droite
            dimension = new Point(40, 30);
            position.X = (this.position.X + this.dimensions.X) -
                         (dimension.X + 10);
            AjouterRectangle("fenetreD", position, dimension, Color.Navy, Color.Black, 2);
            
            // création porte
            dimension = new Point(60, 80);
            position.X = this.position.X +
                         this.dimensions.X / 2 -
                         dimension.X / 2;
            position.Y = this.position.Y + 20;
            AjouterRectangle("porte",position, dimension, Color.Brown);
            
            // création poignée
            dimension = new Point(15, 10);
            position.X = elements["porte"].Position.X +
                         elements["porte"].Dimension.X -
                         dimension.X - 5;
            position.Y = elements["porte"].Position.Y +
                         elements["porte"].Dimension.Y / 2;
            AjouterRectangle("poignee", position, dimension, Color.Yellow);
            
            // création roue gauche
            dimension = new Point(80, 10);
            position.X = this.position.X - dimension.X / 2;
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;
            AjouterDisque("roueG", position, dimension, Color.Brown);
            
            // création roue droite
            dimension = new Point(80, 10);
            position.X = this.position.X + this.dimensions.X - dimension.X / 2;
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;
            AjouterDisque("roueD", position, dimension, Color.Brown);
            
            // création point de référence
            dimension = new Point(15, 10);
            position.X = this.position.X - dimension.X / 2;
            position.Y = this.position.Y - dimension.X / 2;
            AjouterDisque("pointRef", position, dimension, Color.Black);

            elements["fenetreD"].angle = 20;
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
        
        public override string ToString()
        {
            compteur++;
            return "Carrosse - " + compteur;
        }
    }
}