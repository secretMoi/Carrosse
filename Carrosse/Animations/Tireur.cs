using System.Drawing;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Tireur : Animation
    {
        public Tireur(Point position) : base(position)
        {
            element = new Bonhomme(position);
        }

        private void SetAnime()
        {
            element.GetFigure("BrasDroit").Rotation.SetRotation(70, 85);
            element.GetFigure("JambeGauche").Rotation.SetRotation(40, 50);
            element.GetFigure("JambeDroite").Rotation.SetRotation(330, 340);

            animationInitialisee = true;
        }

        public override void Anime()
        {
            if(!animationInitialisee)
                SetAnime();
            
            element.GetFigure("BrasDroit").Rotation.Tourne(0.2);
            element.GetFigure("JambeGauche").Rotation.Tourne(0.2);
            element.GetFigure("JambeDroite").Rotation.Tourne(0.2);
        }
    }
}