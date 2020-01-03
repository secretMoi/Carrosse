using System.Drawing;

namespace Carrosse.Figures
{
    public class Arc : Figure
    {
        private float angleDebut;
        private float amplitude;
        
        public Arc(Point position, Point dimension, Color contour, int largeurContour, float angleDebut, float amplitude) : base(position, dimension, null, contour, largeurContour)
        {
            this.angleDebut = angleDebut;
            this.amplitude = amplitude;
        }

        public override void Genere()
        {
            Graphique.DrawArc(Contour, position.X, position.Y,
                dimension.X, dimension.Y,
                angleDebut, amplitude);
        }
    }
}