using System.Drawing;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Spectateur : Animation
    {
        public Spectateur(Point position) : base(position)
        {
            element = new Bonhomme(position);
        }
        
        private void SetAnime()
        {
            element.GetFigure("BrasDroit").Rotation.SetRotation(40, 85);
            element.GetFigure("JambeGauche").Rotation.SetRotation(10, 30);
            element.GetFigure("JambeDroite").Rotation.SetRotation(330, 350);

            animationInitialisee = true;
        }

        public override void Anime()
        {
            if(!animationInitialisee)
                SetAnime();
            
            element.GetFigure("BrasDroit").Rotation.Tourne(0.4);
            element.GetFigure("JambeGauche").Rotation.Tourne(0.4);
            element.GetFigure("JambeDroite").Rotation.Tourne(0.4);
        }
    }
}