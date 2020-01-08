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
        protected readonly Dictionary<string, Figure> elements; // contient les figures de l'élément
        protected Point position; // position courante de l'élément
        protected Point dimensions; // utlisé lors de la création de chaque figure
        protected double zoom;

        public Element(Point position)
        {
            elements = new Dictionary<string, Figure>();
            
            this.position = position;

            this.zoom = 1;
        }

        // change la mise à l'échelle'
        public virtual void Zoom(double zoom)
        {
            this.zoom = zoom;
        }

        // permet de mettre à l'échelle un élément
        protected void Dimensionne(int x, int y)
        {
            dimensions = new Point((int) (x * zoom), (int) (y * zoom));
        }

        // affiche toutes les figures de l'élément
        public virtual void Affiche(Graphics graphics)
        {
            // redessine toutes les parties des éléments
            foreach (Figure figure in ListeElements())
            {
                figure.Afficher(graphics);

                // indique aux enfants de redéfinir leur position selon la rotation du parent
                foreach (string enfant in figure.ListeEnfants())
                {
                    // récupère le nom de la méthode dynamiquement
                    MethodInfo method = GetType().GetMethod(enfant, BindingFlags.Instance | BindingFlags.Public);
                    method?.Invoke(this, null);
                }
            }
        }
        
        protected void AjouterRectangle(string cle, Color? remplissage = null, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Rectangle(position, dimensions, remplissage, contour, largeurContour));
        }
        
        protected void AjouterDisque(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Disque(position, dimensions.X, remplissage, contour, largeurContour));
        }
        
        protected void AjouterCercle(string cle, Color contour, int largeurContour = 1)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Cercle(position, dimensions.X, contour, largeurContour));
        }
        
        protected void AjouterEllipse(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Ellipse(position, dimensions, remplissage, contour, largeurContour));
        }
        
        protected void AjouterLigne(string cle, Color contour, int largeurContour)
        {
            if (elements.ContainsKey(cle)) return;

            Point positionSource = position;
            Point positionDestination = dimensions;
            elements.Add(cle, new Ligne(positionSource, positionDestination, contour, largeurContour));
        }

        protected void AjouterArc(string cle, Color contour, int largeurContour, float angleDebut, float amplitude)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Arc(position, dimensions, contour, largeurContour, angleDebut, amplitude));
        }

        // déplace à une position donnée
        public void Deplace(Point positionDestination)
        {
            positionDestination.X -= position.X;
            positionDestination.Y -= position.Y;
            
            Deplace(positionDestination.X, positionDestination.Y);
        }

        // déplace en translation
        public void Deplace(int x, int y = 0)
        {
            Figure figure;

            position.X += x;
            position.Y += y;
            
            for (int id = 0; id < elements.Values.Count; id++)
            {
                figure = elements.ElementAt(id).Value;

                figure?.Deplace(figure.Position.X + x, figure.Position.Y + y);
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

        public void RotationFigure(string cle, double angle)
        {
            if(elements.ContainsKey(cle))
                elements[cle].Rotation.Position(angle);
        }

        protected void AjoutEnfant(string enfant, string parent)
        {
            // si les clés existent
            if (elements.ContainsKey(parent) && elements.ContainsKey(enfant))
                elements[parent].AjoutEnfant(enfant);
        }
        
        // rectifie la position par rapport au parent
        protected void AjustePosition(string enfant, string parent, Point positionPreCalculee = default)
        {
            if (positionPreCalculee == default)
                elements[enfant].Position = elements[parent].PointAdjacent(Figure.Y);
            else
                elements[enfant].Position = positionPreCalculee;
            
            AjoutEnfant(enfant, parent);
        }

        public Figure GetFigure(string cle)
        {
            // on vérifie l'existence de la clé
            if (!elements.ContainsKey(cle)) return null;

            return elements[cle];
        }

        public Point Position(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Position;
            
            return position;
        }

        public Point GetPosition => position;
        public Point GetDimension => dimensions;

        public Point Dimension(string cle)
        {
            if (GetFigure(cle) != null)
                return GetFigure(cle).Dimension;
            
            return dimensions;
        }

        public Dictionary<string, Figure> ListeFigures()
        {
            return elements;
        }
    }
}