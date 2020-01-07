using System.Drawing;

namespace Carrosse.Elements
{
    public class Cheveux : RessourceImage
    {
        public Cheveux(Point position) : base(position)
        {
            dimensions.X = 200;
            dimensions.Y = 200;

            nomFichier = "cheveux.png";
            
            ChargeImage();
        }
    }
}