using System;
using System.Diagnostics;
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

        private const bool HORLOGIQUE = true;
        private const bool ANTI_HORLOGIQUE = false;
        
        public Rotation()
        {
            sensRotation = HORLOGIQUE;
            sensibiliteAngle = 0.1;
        }
        
        public void SetRotation (double angleDebut, double angleFin)
        {
            this.angleFin = angleFin;
            this.angleDebut = angleDebut;
        }
        
        public Point RotationPoint(Point positionDepart, Point point)
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

            point.X = temp.X + positionDepart.X;
            point.Y = temp.Y + positionDepart.Y;

            return point;
        }

        public void Tourne(double pas)
        {
            if(sensRotation == HORLOGIQUE)
                angle += pas;
            else
                angle += pas;
            
            

            /*if (angle >= 360 - angleFin)
                sensRotation = ANTI_HORLOGIQUE;
            if (angle <= 360 - angleDebut)
                sensRotation = HORLOGIQUE;*/
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

        private double CorrigeAngle(double angle)
        {
            if (angle < 0 || angle >= 360)
                angle = Math.Abs(angle) % 360;

            return angle;
        }

        public double Angle
        {
            get => angle;
            set => angle = Math.Abs(value) % 360;
        }

        public double SensibiliteAngle => sensibiliteAngle;
    }
}