﻿using System;
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
        protected readonly Dictionary<string, Figure> elements; // contient les éléments de l'élément
        protected Point position; // position courante de l'élément
        protected Point dimensions; // tailles de l'élément
        protected Point dimensionFigure; // utlisé lors de la création de chaque figure

        public Element(Point position)
        {
            elements = new Dictionary<string, Figure>();
            
            this.position = position;
        }

        public virtual void Affiche(Graphics graphics)
        {
            // redessine toutes les parties des éléments
            foreach (Figure figure in ListeElements())
            {
                figure.Afficher(graphics);

                foreach (string enfant in figure.ListeEnfants())
                {
                    MethodInfo method = GetType().GetMethod(enfant, BindingFlags.Instance | BindingFlags.Public);
                    method?.Invoke(this, null);
                }
            }
        }
        
        protected void AjouterRectangle(string cle, Color? remplissage = null, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Rectangle(position, dimensionFigure, remplissage, contour, largeurContour));
        }
        
        protected void AjouterDisque(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Disque(position, dimensionFigure.X, remplissage, contour, largeurContour));
        }
        
        protected void AjouterCercle(string cle, Color contour, int largeurContour)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Cercle(position, dimensionFigure.X, contour, largeurContour));
        }
        
        protected void AjouterEllipse(string cle, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Ellipse(position, dimensionFigure, remplissage, contour, largeurContour));
        }
        
        protected void AjouterLigne(string cle, Color contour, int largeurContour)
        {
            if (elements.ContainsKey(cle)) return;

            Point positionSource = position;
            Point positionDestination = dimensionFigure;
            elements.Add(cle, new Ligne(positionSource, positionDestination, contour, largeurContour));
        }

        protected void AjouterArc(string cle, Color contour, int largeurContour, float angleDebut, float amplitude)
        {
            if (elements.ContainsKey(cle)) return;
            elements.Add(cle, new Arc(position, dimensionFigure, contour, largeurContour, angleDebut, amplitude));
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