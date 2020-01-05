using System.Diagnostics;
using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Elements
{
    public class Bonhomme : Element
    {
        private static int compteur;
        public Bonhomme(Point position) : base(position)
        {
            type = "Bonhomme";
            // création tête
            Point dimension = new Point(100, 100);
            AjouterDisque("tete", position, dimension, Color.Bisque);

            // création bras gauche
            dimension = new Point(40, 80);
            position.X += elements["tete"].Dimension.X / 2 -
                          dimension.X / 2 + 5;
            position.Y += elements["tete"].Dimension.Y + 40;
            AjouterEllipse("brasG", position, dimension, Color.Brown, Color.Black, 1);

            // création corps
            Corps();
            
            // création haut jambe gauche
            dimension = new Point(40, 80);
            position.X = elements["brasG"].Position.X;
            position.Y = elements["corps"].Position.Y +
                         elements["corps"].Dimension.Y;
            AjouterEllipse("jambeG", position, dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("jambeG", 40);
            
            // genou gauche
            dimension = new Point(30, 30);
            position.X = elements["jambeG"].PointAdjacent(Figure.Y).X;
            position.Y = elements["jambeG"].PointAdjacent(Figure.Y).Y
                         - dimension.Y / 2;
            AjouterDisque("genouG", position, dimension, Color.CadetBlue, Color.Black, 1);
            
            // bas jambe gauche
            dimension = new Point(40, 80);
            AjouterEllipse("basJambeG", elements["jambeG"].PointAdjacent(Figure.Y), dimension, Color.CadetBlue, Color.Black, 1);
            
            // création haut jambe droite
            position.X = elements["jambeG"].Position.X - 5;
            position.Y = elements["jambeG"].Position.Y;
            AjouterEllipse("jambeD", position, dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("jambeD", -20);
            
            // genou droit
            dimension = new Point(30, 30);
            position.X = elements["jambeD"].PointAdjacent(Figure.Y).X;
            position.Y = elements["jambeD"].PointAdjacent(Figure.Y).Y
                         - dimension.Y / 2;
            AjouterDisque("genouD", position, dimension, Color.CadetBlue, Color.Black, 1);
            
            // bas jambe droite
            dimension = new Point(40, 80);
            AjouterEllipse("basJambeD", elements["jambeD"].PointAdjacent(Figure.Y), dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("basJambeD", -40);

            // création bras droit
            BrasDroit();

            // création avant-bras droit
            avantBrasD();
            
            // création pied gauche
            dimension = new Point(70,30);
            AjouterEllipse("piedG", elements["basJambeG"].PointAdjacent(Figure.Y), dimension, Color.Wheat, Color.Black, 1);

            // création pied droit
            AjouterEllipse("piedD", elements["basJambeD"].PointAdjacent(Figure.Y), dimension, Color.Wheat, Color.Black, 1);


            objetFini = true;
        }

        public void BrasDroit()
        {
            Point dimension = new Point(40, 80);
            
            position.X = elements["brasG"].Position.X - 5;
            position.Y = elements["brasG"].Position.Y;
            
            AjouterEllipse("brasD", position, dimension, Color.Brown, Color.Black, 1);
            
            RotationFigure("brasD", 60);
        }

        public void avantBrasD() //todo créer un système de dépendances, propageant le message que les figures enfantes doivent bouger selon la parente
        {
            Point dimension = new Point(40, 80);

            AjouterEllipse("avantBrasD", elements["brasD"].PointAdjacent(Figure.Y), dimension, Color.Brown, Color.Black, 1);
            
            AjustePosition("avantBrasD", "brasD");
            
            RotationFigure("avantBrasD", 80);
            
            AjoutEnfant("brasD", "avantBrasD");
        }
        
        public void Corps()
        {
            Point dimension = new Point(80, 160);
            
            position.X = elements["tete"].Position.X + 5;
            position.Y = elements["tete"].Position.Y +
                         elements["tete"].Dimension.Y;
            
            AjouterEllipse("corps", position, dimension, Color.Navy);
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