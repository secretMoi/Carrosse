using System.Drawing;

namespace Carrosse.Elements
{
    public class Volcan : RessourceImage
    {
        public Volcan(Point position) : base(position)
        {
            dimensions.X = 400;
            dimensions.Y = 400;
            
            nomFichier = "volcan.png";
            
            ChargeImage();
        }
    }
}