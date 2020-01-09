using System.Drawing;

namespace Carrosse.Elements
{
    public class Chapeau : Element
    {
        public Chapeau(Point position) : base(position)
        {
            PartieHaute();
            
            PartieBasse();
        }
        
        public void PartieHaute()
        {
            Dimensionne(100,30);
            
            AjouterRectangle("PartieHaute", Color.CadetBlue);
        }

        public void PartieBasse()
        {
            Dimensionne(150,45);
            position.X = elements["PartieHaute"].Position.X;
            position.Y = elements["PartieHaute"].Position.Y
                         + elements["PartieHaute"].Dimension.Y;
            
            AjouterRectangle("PartieBasse", Color.Teal);
        }
    }
}