using System.Drawing;
using Carrosse.Elements;
using Carrosse.Figures;

namespace Carrosse.Animations
{
    public abstract class Animation
    {
        protected static int tempsPourCycle;
        
        protected Element element;
        protected Point position;
        protected bool animationInitialisee;
        protected Figure parente;
        
        public Animation(Point position = default)
        {
            this.position = position;
            animationInitialisee = false;
        }

        public virtual void Hydrate(Figure parente)
        {
        }

        public abstract void Anime();

        public static void SetPeriode(int periode)
        {
            tempsPourCycle = periode;
        }

        protected double Angle(string figure)
        {
            return element.GetFigure(figure).Rotation.AngleInverse();
        } 

        public Figure GetFigure(string nomFigure)
        {
            return element.GetFigure(nomFigure);
        }
        public Element Element => element;
    }
}