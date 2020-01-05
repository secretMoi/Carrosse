using System;
using System.Drawing;

namespace Carrosse.Figures
{
    public class Rotation
    {
        private double angle;
        private double angleDebut;
        private double angleFin;
        private bool sensRotation;
        private readonly double sensibiliteAngle;
        
        public Rotation()
        {
            sensRotation = true;
            sensibiliteAngle = 0.1;
        }
        
        public Point RotationPoint(Point positionDepart, Point point)
        {
            /*** calcul angle de la figure parente ***/
            
            Point temp = new Point();
            double angleRadian = Figures.Rotation.DegreToRadian(angle);
            
            /*
             * x' = cos(theta)*(x-xc) - sin(theta)*(y-yc) + xc
             * y' = sin(theta)*(x-xc) + cos(theta)*(y-yc) + yc
             */

            temp.X = (int)(Math.Cos(angleRadian) * point.X - Math.Sin(angleRadian) * point.Y);
            temp.Y = (int)(Math.Sin(angleRadian) * point.X + Math.Cos(angleRadian) * point.Y);

            point.X = temp.X + positionDepart.X;
            point.Y = temp.Y + positionDepart.Y;

            return point;
        }
        
        public void SetRotation (double angleDebut, double angleFin)
        {
            this.angleFin = DegreToRadian(angleFin);
            this.angleDebut = DegreToRadian(angleDebut);
        }

        // todo ne marche pas
        public double Tourne(double pas)
        {
            pas = -pas;
            
            if(sensRotation)
                angle += pas;
            else
                angle -= pas;

            if (angle >= angleFin)
                sensRotation = false;
            if (angle <= angleDebut)
                sensRotation = true;
            
            return angle;
        }
        
        public void Position(double angle)
        {
            angle = 360 - angle;

            this.angle = angle;
        }
        
        public static double DegreToRadian(double angle)
        {
            return angle * Math.PI / 180;
        }

        public double Angle
        {
            get => angle;
            set => angle = value;
        }

        public double SensibiliteAngle => sensibiliteAngle;
    }
}