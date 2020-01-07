using System.Drawing;

namespace Carrosse.Elements
{
    public class Balle : RessourceImage
    {
        public Balle(Point position) : base(position)
        {
            //elements.Add("Balle", null);
            
            dimensions.X = 59;
            dimensions.Y = 164;

            nomFichier = "balle.png";
            
            ChargeImage();
        }
    }
}