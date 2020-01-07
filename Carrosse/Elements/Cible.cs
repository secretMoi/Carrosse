using System.Drawing;

namespace Carrosse.Elements
{
    public class Cible : RessourceImage
    {
        public Cible(Point position) : base(position)
        {
            dimensions.X = 200;
            dimensions.Y = 200;

            nomFichier = "cible2.png";
            
            ChargeImage();
        }
    }
}