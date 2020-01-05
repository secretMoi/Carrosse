using System.Drawing;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Animation
    {
        protected static int tempsPourCycle;
        
        protected Element element;
        protected Point position;
        
        public Animation(Point position)
        {
            this.position = position;
        }

        public static void SetPeriode(int periode)
        {
            tempsPourCycle = periode;
        }

        public Element Element => element;
    }
}