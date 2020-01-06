using System.Diagnostics;
using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Elements
{
    public class Bonhomme : Element
    {
        private static int compteur;
        private Point dimension;
        public Bonhomme(Point position) : base(position)
        {
            // création tête
            Tete();

            // création bras gauche
            BrasGauche();

            // création Corps
            Corps();
            
            // création haut jambe gauche
            JambeGauche();
            
            // genou gauche
            GenouGauche();
            
            // bas jambe gauche
            JambeGaucheBas();
            
            // création haut jambe droite
            JambeDroite();
            
            // genou droit
            GenouDroit();
            
            // bas jambe droite
            JambeDroiteBas();

            // création bras droit
            BrasDroit();

            // création avant-bras droit
            AvantBrasDroit();
            
            // création pied gauche
            PiedGauche();

            // création pied droit
            PiedDroit();


            objetFini = true;
        }

        public void Tete()
        {
            dimension = new Point(100, 100);
            
            AjouterDisque("Tete", position, dimension, Color.Bisque);
        }

        public void BrasGauche()
        {
            dimension = new Point(40, 80);
            position.X += elements["Tete"].Dimension.X / 2 -
                          dimension.X / 2 + 5;
            position.Y += elements["Tete"].Dimension.Y + 40;
            AjouterEllipse("BrasGauche", position, dimension, Color.Brown, Color.Black, 1);
        }

        public void BrasDroit()
        {
            dimension = new Point(40, 80);
            position.X = elements["BrasGauche"].Position.X - 5;
            position.Y = elements["BrasGauche"].Position.Y;
            AjouterEllipse("BrasDroit", position, dimension, Color.Brown, Color.Black, 1);
            
            RotationFigure("BrasDroit", 60);
        }

        public void AvantBrasDroit()
        {
            dimension = new Point(40, 80);

            AjouterEllipse("AvantBrasDroit", elements["BrasDroit"].PointAdjacent(Figure.Y), dimension, Color.Brown, Color.Black, 1);
            
            AjustePosition("AvantBrasDroit", "BrasDroit");
            
            RotationFigure("AvantBrasDroit", 80);
            
            AjoutEnfant("BrasDroit", "AvantBrasDroit");
        }
        
        public void Corps()
        {
            dimension = new Point(80, 160);
            
            position.X = elements["Tete"].Position.X + 5;
            position.Y = elements["Tete"].Position.Y +
                         elements["Tete"].Dimension.Y;
            
            AjouterEllipse("Corps", position, dimension, Color.Navy);
        }

        public void JambeGauche()
        {
            dimension = new Point(40, 80);
            position.X = elements["BrasGauche"].Position.X;
            position.Y = elements["Corps"].Position.Y +
                         elements["Corps"].Dimension.Y;
            AjouterEllipse("JambeGauche", position, dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeGauche", 40);
        }

        public void GenouGauche()
        {
            dimension = new Point(30, 30);
            position.X = elements["JambeGauche"].PointAdjacent(Figure.Y).X;
            position.Y = elements["JambeGauche"].PointAdjacent(Figure.Y).Y
                         - dimension.Y / 2;
            AjouterDisque("GenouGauche", position, dimension, Color.CadetBlue, Color.Black, 1);
        }

        public override void Centre(ref Point point)
        {
            point.X = point.X - 
                      elements["Corps"].Dimension.X / 2;
            point.Y = point.Y - 
                      elements["Tete"].Dimension.Y - elements["Corps"].Dimension.Y / 2;
        }
        
        public void JambeGaucheBas()
        {
            dimension = new Point(40, 80);
            AjouterEllipse("JambeGaucheBas", elements["JambeGauche"].PointAdjacent(Figure.Y), dimension, Color.CadetBlue, Color.Black, 1);
        }

        public void JambeDroite()
        {
            position.X = elements["JambeGauche"].Position.X - 5;
            position.Y = elements["JambeGauche"].Position.Y;
            AjouterEllipse("JambeDroite", position, dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeDroite", -20);
        }
        
        public void GenouDroit()
        {
            dimension = new Point(30, 30);
            position.X = elements["JambeDroite"].PointAdjacent(Figure.Y).X;
            position.Y = elements["JambeDroite"].PointAdjacent(Figure.Y).Y
                         - dimension.Y / 2;
            AjouterDisque("GenouDroit", position, dimension, Color.CadetBlue, Color.Black, 1);
        }

        public void JambeDroiteBas()
        {
            dimension = new Point(40, 80);
            AjouterEllipse("JambeDroiteBas", elements["JambeDroite"].PointAdjacent(Figure.Y), dimension, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeDroiteBas", -40);
        }

        public void PiedGauche()
        {
            dimension = new Point(70,30);
            AjouterEllipse("PiedGauche", elements["JambeGaucheBas"].PointAdjacent(Figure.Y), dimension, Color.Wheat, Color.Black, 1);
        }

        public void PiedDroit()
        {
            AjouterEllipse("PiedDroit", elements["JambeDroiteBas"].PointAdjacent(Figure.Y), dimension, Color.Wheat, Color.Black, 1);
        }
        
        public override string ToString()
        {
            compteur++;
            return "Bonhomme - " + compteur;
        }
    }
}