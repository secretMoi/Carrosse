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
        private Dictionary<string, Figure> elements; // contient les éléments du carrosse
        //private Dictionary<string, Point> decalage; // définit leur décalage par rapport au carrosse
        private Point position; // position courante du carrosse
        private Point dimensions; // tailles du carrosse

        public Carrosse(Point position)
        {
            elements = new Dictionary<string, Figure>();
            //decalage = new Dictionary<string, Point>();
            
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
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;
            AjouterRoue("roueG", position, dimension, Color.Brown);
            
            // création roue droite
            dimension = new Point(80, 10);
            position.X = this.position.X + this.dimensions.X - dimension.X / 2;
            position.Y = this.position.Y + this.dimensions.Y - dimension.X / 2;
            AjouterRoue("roueD", position, dimension, Color.Brown);
        }

        private void AjouterRectangle(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Rectangle(position, dimension, remplissage, contour, largeurContour));
            
            //LieDecalage(cle, position);
        }
        
        private void AjouterRoue(string cle, Point position, Point dimension, Color remplissage)
        {
            elements.Add(cle, new Cercle(position, dimension.X, remplissage));
            
            //LieDecalage(cle, position);
        }

        /*private void LieDecalage(string cle, Point position)
        {
            position.X -= this.position.X;
            position.Y -= this.position.Y;
            
            decalage.Add(cle, position);
        }*/

        public void Deplace(Point positionDestination)
        {
            positionDestination.X -= position.X;
            positionDestination.Y -= position.Y;
            
            Deplace(positionDestination.X, positionDestination.Y);
        }

        public void Deplace(int x, int y = 0)
        {
            Figure figure;

            position.X += x;
            position.Y += y;
            
            for (int id = 0; id < elements.Values.Count; id++)
            {
                figure = elements.ElementAt(id).Value;
                
                figure.SetPositionX(figure.Position.X + x);
                figure.SetPositionY(figure.Position.Y + y);
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