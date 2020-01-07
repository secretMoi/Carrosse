using System.Drawing;

namespace Carrosse.Elements
{
    public class Personnage : RessourceImage
    {
        public Personnage(Point position) : base(position)
        {
            //elements.Add("Personnage", null);
            
            dimensions.X = 100;
            dimensions.Y = 100;

            nomFichier = "barney.png";
            
            ChargeImage();
        }
    }
}