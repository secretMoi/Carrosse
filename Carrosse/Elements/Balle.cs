using System.Drawing;

namespace Carrosse.Elements
{
    public class Balle : RessourceImage
    {
        public Balle(Point position) : base(position)
        {
            dimensions.X = 59;
            dimensions.Y = 164;

            nomFichier = "balle.png";
            
            ChargeImage();
        }
        
        public override string ToString()
        {
            return "Balle";
        }
    }
}