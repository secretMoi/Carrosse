using System.Drawing;
using Carrosse.Figures;

namespace Carrosse
{
    public class Bonhomme : Element
    {
        private static int compteur;
        public Bonhomme(Point position) : base(position)
        {
            // création tête
            Point dimension = new Point(50, 100);
            AjouterCercle("tete", position, dimension, Color.Bisque);
            
            // création bras gauche
            dimension = new Point(20, 80);
            position.X += elements["tete"].Dimension.X / 2 -
                          dimension.X / 2 + 5;
            position.Y = position.Y +
                         elements["tete"].Dimension.Y + 20;
            AjouterEllipse("brasG", position, dimension, Color.Brown, Color.Black, 1);

            // création corps
            dimension = new Point(40, 80);
            position.X = elements["tete"].Position.X + 5;
            position.Y = elements["tete"].Position.Y +
                         elements["tete"].Dimension.Y;
            AjouterEllipse("corps", position, dimension, Color.Navy);
            
            // création jambe gauche
            dimension = new Point(20, 80);
            position.X = elements["brasG"].Position.X;
            position.Y = elements["corps"].Position.Y +
                         elements["corps"].Dimension.Y;
            AjouterEllipse("jambeG", position, dimension, Color.CadetBlue, Color.Black, 1);
            
            // création jambe droite
            position.X = elements["jambeG"].Position.X - 5;
            position.Y = elements["jambeG"].Position.Y;
            AjouterEllipse("jambeD", position, dimension, Color.CadetBlue, Color.Black, 1);

            // création bras droit
            position.X = elements["brasG"].Position.X - 5;
            position.Y = elements["brasG"].Position.Y;
            AjouterEllipse("brasD", position, dimension, Color.Brown, Color.Black, 1);
            
            elements["brasD"].Rotation(-30.0f);
        }

        public override void Centre(ref Point point)
        {
            point.X = point.X - 
                      elements["corps"].Dimension.X / 2;
            point.Y = point.Y - 
                      elements["tete"].Dimension.Y - elements["corps"].Dimension.Y / 2;
        }

        public override string ToString()
        {
            compteur++;
            return "Bonhomme - " + compteur;
        }
    }
}