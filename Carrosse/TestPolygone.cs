using System.Drawing;
using Carrosse.Elements;
using Carrosse.Figures;

namespace Carrosse
{
    public class TestPolygone : Element
    {
        private static int compteur;
        public TestPolygone(Point position) : base(position)
        {
            this.dimensions = new Point(200, 100);
            
            // création corps
            Point dimension = new Point(200, 100);
            AjouterPolygone("corps", position, dimension, Color.Yellow, Color.Firebrick, 3);
            
        }
        
        protected void AjouterPolygone(string cle, Point position, Point dimension, Color remplissage, Color? contour = null, int largeurContour = 0)
        {
            elements.Add(cle, new Polygone(position, dimension, remplissage, contour, largeurContour));
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
        
        public override string ToString()
        {
            compteur++;
            return "Polygone - " + compteur;
        }
    }
}