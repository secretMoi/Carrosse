using System.Diagnostics;
using System.Drawing;
using Carrosse.Elements;
using Carrosse.Figures;

namespace Carrosse.Animations
{
    public class Carabine : Animation
    {
        public Carabine() : base()
        {
            element = new Elements.Carabine(position);
        }

        public override void Hydrate(params object[] parametre)
        {
            this.parente = (Figure) parametre[0];
        }

        public override void Anime()
        {
            Point nouvellePosition;
            
            nouvellePosition = parente.PointAdjacent(Figure.Y);
            nouvellePosition.X -= element.GetFigure("crosse").Dimension.X
                                  + element.GetFigure("corps").Dimension.X / 3
                                  - 7;
            nouvellePosition.Y -= element.GetFigure("crosse").Dimension.Y;
            
            element.Deplace(nouvellePosition);
        }
    }
}