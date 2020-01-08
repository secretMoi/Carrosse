using System.Diagnostics;
using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Elements
{
    public class RayonsCentre : Element
    {
        public RayonsCentre(Point position) : base(position)
        {
            Ligne();
        }

        // todo espacer le point de rotation
        public void Ligne()
        {
            Dimensionne(800, 5);
            string ligneCourante;
            
            for (int i = 0; i < 18; i++)
            {
                ligneCourante = "Ligne" + i;
                
                AjouterRectangle(ligneCourante, Color.Firebrick);

                if (i > 0) // si une parente est déjà créée
                {
                    RotationFigure(
                        ligneCourante, 
                        elements["Ligne" + (i-1)].Rotation.AngleInverse() - 20
                    );
                }
            }
        }
        
        public override void Affiche(Graphics graphics)
        {
            // redessine toutes les parties des éléments
            foreach (Figure figure in ListeElements())
            {
                Ligne();
                
                figure.Afficher(graphics);
            }
        }
    }
}