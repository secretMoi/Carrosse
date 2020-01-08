using System.Diagnostics;
using System.Drawing;
using Carrosse.Figures;

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
                    //AjustePosition(ligneCourante, "Ligne" + (i-1), position);
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