using System.Drawing;

namespace Carrosse.Animations
{
    public class Tireur : Animation
    {
        public Tireur(Point position) : base(position)
        {
            element = new Elements.Bonhomme(position);
        }

        public override void Anime()
        {
            if(!animationInitialisee)
                SetAnime();
            
            element.GetFigure("BrasDroit").Rotation.Tourne(0.4);
        }

        private void SetAnime()
        {
            element.GetFigure("BrasDroit").Rotation.SetRotation(40, 70);

            animationInitialisee = true;
        }
    }
}