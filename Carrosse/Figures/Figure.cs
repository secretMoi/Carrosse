using System;
using System.Drawing;
using System.Windows.Forms;

namespace Carrosse.Figures
{
    public abstract class Figure
    {
        public Point position;
        protected Point dimension;
        protected double angle;
        private double sensibiliteAngle;
        protected Color CouleurRemplissage;
        protected Color CouleurContour;
        protected int largeurContour;
        
        protected static Graphics GraphiquePartage;
        protected Graphics Graphique;
        protected SolidBrush Remplissage;
        protected Pen Contour;

        public const bool X = true;
        public const bool Y = false;

        public Figure(Point position, Point dimension, Color? couleurRemplissage = null, Color? contour = null, int largeurContour = 0)
        {
            this.position = position;
            this.dimension = dimension;
            this.angle = 0.0;
            this.sensibiliteAngle = 0.1;

            if (couleurRemplissage != null)
                this.CouleurRemplissage = (Color) couleurRemplissage;
            if (contour != null)
                this.CouleurContour = (Color) contour;
            this.largeurContour = largeurContour;

            Graphique = GraphiquePartage;
            
            Dessine();
        }

        public static void InitialiseConteneur(PictureBox pictureBox)
        {
            GraphiquePartage = Graphics.FromHwnd(pictureBox.Handle);
        }

        public void Afficher(Graphics graphics)
        {
            Dessine(graphics);
        }

        public abstract void Genere();

        public void Dessine(Graphics graphics = null)
        {
            PreparationAffichage(graphics);
            
            Genere();
            
            FinDessin();
        }

        public void FinDessin()
        {
            // permet de rectifier l'angle pour ne pas impacter les autres éléments
            CorrectionAngle(true);
        }

        protected void PreparationAffichage(Graphics graphics = null)
        {
            if(Remplissage == null)
                Remplissage = new SolidBrush(CouleurRemplissage);
            if(Contour == null)
                Contour = new Pen(CouleurContour, largeurContour);
            
            if (graphics != null)
                Graphique = graphics;

            CorrectionAngle();
        }

        protected void CorrectionAngle(bool corrige = false)
        {
            if (Math.Abs(angle) > sensibiliteAngle)
            {
                int inverseur = 1;
                if (corrige) inverseur = -1;
                Graphique.TranslateTransform(position.X, position.Y);
                // rotation
                Graphique.RotateTransform((float) (inverseur * angle));
                Graphique.TranslateTransform(-(position.X), -position.Y);
            }
        }
        
        public void Rotation(double angle)
        {
            angle = 360 - angle;

            this.angle = angle;
        }
        
        public void Tourne(double angle)
        {
            angle = -angle;

            this.angle += angle;
        }

        public virtual void Deplace(int x, int y)
        {
            position.X = x;
            position.Y = y;
        }

        public Point PointOppose()
        {
            Point pointFin = new Point();
            
            // rayon du pt1 au point 3
            double distanceFin = Math.Sqrt(dimension.X * dimension.X + dimension.Y * dimension.Y);
            
            // angle du pt1 au pt 3
            double angleFin = Math.Atan((double)dimension.Y / (double)dimension.X);

            // coordonnées du pt 3 à l'état initial'
            pointFin.X = (int)(distanceFin * Math.Cos(angleFin));
            pointFin.Y = (int)(distanceFin * Math.Sin(angleFin));
            // position coint opposé initiale
            
            
            // rajouter l'angle de l'objet
            return RotationPoint(pointFin);
        }
        
        public Point PointAdjacent(bool xy = X)
        {
            Point pointFin = new Point();

            /*** calcul point de départ ***/
            // si le côté dominant est en absisse
            if (xy == X) pointFin.X += dimension.X;
            else pointFin.Y += dimension.Y;
            /*** fin point de départ ***/

            /*** calcul angle de la figure parente ***/
            return RotationPoint(pointFin);
        }

        private Point RotationPoint(Point point)
        {
            /*** calcul angle de la figure parente ***/
            
            Point temp = new Point();
            double angleRadian = DegreToRadian(angle);
            
            /*
             * x' = cos(theta)*(x-xc) - sin(theta)*(y-yc) + xc
             * y' = sin(theta)*(x-xc) + cos(theta)*(y-yc) + yc
             */

            temp.X = (int)(Math.Cos(angleRadian) * point.X - Math.Sin(angleRadian) * point.Y);
            temp.Y = (int)(Math.Sin(angleRadian) * point.X + Math.Cos(angleRadian) * point.Y);

            point.X = temp.X + position.X;
            point.Y = temp.Y + position.Y;

            return point;
        }

        protected double DegreToRadian(double angle)
        {
            return angle * Math.PI / 180;
        }

        public Point Dimension => dimension;
        public Point Position => position;

        public double Angle => 360 - angle;
    }
}