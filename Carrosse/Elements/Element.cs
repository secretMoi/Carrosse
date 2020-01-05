using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using Carrosse.Figures;
using Rectangle = Carrosse.Figures.Rectangle;

namespace Carrosse.Elements
{
    public abstract class Element
    {
        protected readonly Dictionary<string, Figure> elements; // contient les éléments du carrosse
        protected Point position; // position courante du carrosse
        protected Point dimensions; // tailles du carrosse

        protected string type;
        protected bool objetFini;

        public Element(Point position)
        {
            elements = new Dictionary<string, Figure>();
            
            this.position = position;

            objetFini = false;
        }

        public virtual void Affiche(Graphics graphics)
        {
            // redessine toutes les parties des éléments
            foreach (Figure figure in ListeElements())
            {
                figure.Afficher(graphics);

                if (figure.ListeEnfants().Count > 0)
                {
                    for (int i = 0; i < figure.ListeEnfants().Count; i++)
                    {
                        string enfant = figure.ListeEnfants()[i];
                        //Debug.WriteLine(figure.ListeEnfants());
                        
                        // Get the Type for the class
                        Type calledType = Type.GetType(type);
                        
                        
                        //Type t = Type.GetType("Reflection.Order" + "1");
                        MethodInfo method = Type.GetType("Carrosse.Elements.Bonhomme").GetMethod(enfant, BindingFlags.Instance | BindingFlags.Public);
                        method?.Invoke(this, null);
                    }
                }
                

            }
        }
        
        protected void AjouterRectangle(string cle, Point position, Point dimension, Color? remplissage = null, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Rectangle(position, dimension, remplissage, contour, largeurContour));
        }
        
        protected void AjouterDisque(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Disque(position, dimension.X, remplissage, contour, largeurContour));
        }
        
        protected void AjouterCercle(string cle, Point position, Point dimension, Color contour, int largeurContour)
        {
            elements.Add(cle, new Cercle(position, dimension.X, contour, largeurContour));
        }
        
        protected void AjouterEllipse(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Ellipse(position, dimension, remplissage, contour, largeurContour));
        }
        
        protected void AjouterLigne(string cle, Point positionSource, Point positionDestination, Color contour, int largeurContour)
        {
            elements.Add(cle, new Ligne(positionSource, positionDestination, contour, largeurContour));
        }

        protected void AjouterArc(string cle, Point position, Point dimension, Color contour, int largeurContour, float angleDebut, float amplitude)
        {
            elements.Add(cle, new Arc(position, dimension, contour, largeurContour, angleDebut, amplitude));
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

                figure.Deplace(figure.Position.X + x, figure.Position.Y + y);
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

        public void RotationFigure(string cle, int angle)
        {
            if(elements.ContainsKey(cle))
                elements[cle].Rotation.Position(angle);
        }

        protected void AjoutEnfant(string parent, string enfant)
        {
            // si les clés existent
            if (elements.ContainsKey(parent) && elements.ContainsKey(enfant))
            {
                // si la clé n'est pa déjà enregistrée
                if(objetFini == false)
                    elements[parent].AjoutEnfant(enfant);
            }
                
        }

        public Figure GetFigure(string cle)
        {
            Figure figure;
            // on vérifie l'existence de la clé
            if (!elements.TryGetValue(cle, out figure)) return null;

            return elements[cle];
        }

        public Dictionary<string, Figure> ListeFigures()
        {
            return elements;
        }
    }
}