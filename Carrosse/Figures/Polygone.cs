using System;
using System.Drawing;

namespace Carrosse.Figures
{
    public class Polygone : Figure
    {
        
        public Polygone(Point position, Point dimension, Color couleurRemplissage, Color? contour = null, int largeurContour = 0) : base(position, dimension, couleurRemplissage, contour, largeurContour)
        {
            //angle = 10.0f;
        }
        
        public override void Genere()
        {
            //GraphiquePartage.FillPolygon(Remplissage, new []{ CSG, CSD, CIG, CID });
        }
        
        /*public Point CSG
        {
            get { return position; }
        }

        public Point CSD
        {
            get
            {
                return new Point ( 
                    (int)(position.X + Dimension.X * Math.Cos(angle)),
                    (int)(position.Y - Dimension.Y * Math.Sin(angle))
                    );
            }
        }

        public Point CIG
        {
            get
            {
                return new Point(
                    (int)(position.X + dimension.X * Math.Cos(3 * Math.PI / 2 + angle)),
                    (int)(position.Y - Dimension.Y * Math.Sin(3 * Math.PI / 2 + angle))
                    );
            }
        }

        public Point CID
        {
            get
            {
                return new Point(
                    (int)(position.X + dimension.X * Math.Cos(angle) + dimension.Y * Math.Cos(3 * Math.PI / 2 + angle)), 
                    (int)(position.Y - Dimension.Y * Math.Sin(angle) - dimension.Y * Math.Sin(3 * Math.PI / 2 + angle))
                    );
            }
        }*/

    }
}