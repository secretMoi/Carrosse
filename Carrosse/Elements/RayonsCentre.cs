using System.Diagnostics;
using System.Drawing;

namespace Carrosse.Elements
{
    public class RayonsCentre : Element
    {
        private bool initialise;
        public RayonsCentre(Point position) : base(position)
        {
            initialise = false;
            Ligne();
            initialise = true;
        }

        public void Ligne()
        {
            Dimensionne(1000, 5);
            string ligneCourante;
            
            for (int i = 0; i < 18; i++)
            {
                ligneCourante = "Ligne" + i;
                
                AjouterRectangle(ligneCourante, Color.Firebrick);

                if (i > 0) // si une parente est déjà créée
                {
                    Point positionAjustee = position;
                    AjustePosition(ligneCourante, "Ligne" + (i-1), positionAjustee);
                    Debug.WriteLine(elements["Ligne" + (i-1)].Angle + 20);
                    RotationFigure(
                        ligneCourante, 
                        elements["Ligne" + (i-1)].Rotation.AngleInverse() - 20
                    );
                }
            }
        }
    }
}