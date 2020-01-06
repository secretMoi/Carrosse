using System.Drawing;

namespace Carrosse.Elements
{
    public class Personnage : RessourceImage
    {
        public Personnage(Point position) : base(position)
        {
            dimensions.X = 200;
            dimensions.Y = 200;

            nomFichier = "barney.png";
            
            ChargeImage();
        }
    }
}