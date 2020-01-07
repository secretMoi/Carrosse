using System;
using System.Drawing;

namespace Carrosse.Animations
{
    public class Lunette : Animation
    {
        private Random aleatoire;
        private Point positionDepart;
        public Lunette(Point position) : base(position)
        {
            element = new Elements.Lunette(position);
            
            aleatoire = new Random();
        }
        public override void Anime()
        {
            int x = aleatoire.Next(0, 2);
            int y = aleatoire.Next(0, 2);
            int sens = aleatoire.Next(0, 2);

            if (sens == 0)
            {
                x = -x;
                y = -y;
            }
            //todo terminer les valeurs extrêmes
                /*if (element.GetFigure("lunette").Position.X > positionDepart.X + 50) x = 0;
                if (element.GetFigure("lunette").Position.Y > positionDepart.Y + 50) y = 0;*/
            element.Deplace(x, y);
        }
    }
}