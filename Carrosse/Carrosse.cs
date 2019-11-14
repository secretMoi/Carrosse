using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using Carrosse.Figures;
using Rectangle = Carrosse.Figures.Rectangle;

namespace Carrosse
{
    public class Carrosse
    {
        private Dictionary<string, Figure> elements;
        private Dictionary<string, Point> decalage;
        private Point position;
        private Point dimensions;

        public Carrosse(Point position)
        {
            elements = new Dictionary<string, Figure>();
            decalage = new Dictionary<string, Point>();
            
            this.position = position;
            this.dimensions = new Point(200, 100);
            
            // création corps
            Point dimension = new Point(200, 100);
            AjouterRectangle("corps", position, dimension, Color.Yellow, Color.Firebrick, 3);

            // création fenêtre gauche
            dimension = new Point(40, 30);
            position.X = this.position.X + 10;
            position.Y = this.position.Y + 10;
            AjouterRectangle("fenetreG", position, dimension, Color.Navy);
            
            // création fenêtre droite
            dimension = new Point(40, 30);
            position.X = (this.position.X + this.dimensions.X) -
                         (dimension.X + 10);
            position.Y = this.position.Y + 10;
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
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;;
            AjouterRoue("roueG", position, dimension, Color.Brown);
            
            // création roue droite
            dimension = new Point(80, 10);
            position.X = this.position.X + this.dimensions.X - dimension.X / 2;
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;
            AjouterRoue("roueD", position, dimension, Color.Brown);
        }

        private Point PositionElement()
        {
            return new Point();
        }

        private void AjouterRectangle(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Rectangle(position, dimension, remplissage, contour, largeurContour));

            position.X -= this.position.X;
            position.Y -= this.position.Y;
            
            decalage.Add(cle, position);
        }
        
        private void AjouterRoue(string cle, Point position, Point dimension, Color remplissage)
        {
            elements.Add(cle, new Cercle(position, dimension.X, remplissage));
            
            position.X -= this.position.X;
            position.Y -= this.position.Y;

            decalage.Add(cle, position);
        }

        public void Deplace(Point position)
        {
            Figure figure;
            Point decalage;
            
            for (int id = 0; id < elements.Values.Count; id++)
            {
                figure = elements.ElementAt(id).Value;
                decalage = this.decalage.ElementAt(id).Value;
                
                figure.SetPositionX(position.X + decalage.X);
                figure.SetPositionY(position.Y + decalage.Y);
            }
        }

        public List<Figure> ListeElements()
        {
            List<Figure> figures = new List<Figure>();

            foreach (Figure figure in elements.Values)
            {
                figures.Add(figure);
            }

            return figures;
        }
    }
}