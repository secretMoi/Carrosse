using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Carrosse.Figures;
using Rectangle = Carrosse.Figures.Rectangle;

namespace Carrosse
{
    public abstract class Element
    {
        protected Dictionary<string, Figure> elements; // contient les éléments du carrosse
        protected Point position; // position courante du carrosse
        protected Point dimensions; // tailles du carrosse

        public Element(Point position)
        {
            elements = new Dictionary<string, Figure>();
            
            this.position = position;
        }
        
        protected void AjouterRectangle(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Rectangle(position, dimension, remplissage, contour, largeurContour));
        }
        
        protected void AjouterCercle(string cle, Point position, Point dimension, Color remplissage)
        {
            elements.Add(cle, new Cercle(position, dimension.X, remplissage));
        }
        
        protected void AjouterEllipse(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Ellipse(position, dimension, remplissage, contour, largeurContour));
        }

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

        public abstract void Centre(ref Point point);

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