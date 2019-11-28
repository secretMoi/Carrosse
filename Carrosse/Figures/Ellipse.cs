using System;
using System.Drawing;

namespace Carrosse.Figures
{
    public class Ellipse : Figure
    {
        public Ellipse(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) : base(position, dimension, couleurRemplissage, contour, largeurContour)
        {
            
        }
        
        protected override void Genere()
        {
            base.Genere();
            
            Graphique.FillEllipse(Remplissage,largeurContour, largeurContour, 
                dimension.X, dimension.Y);
            
            Graphique.DrawEllipse(Contour,
                largeurContour, largeurContour, 
                dimension.X, dimension.Y); // dessine le cercle dans l'image
        }
    }
}