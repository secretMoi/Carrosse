using System.Diagnostics;
using System.Drawing;
using Carrosse.Figures;

namespace Carrosse.Elements
{
    // todo supprimer les params position/dimension vu qu'ils sont connus de l'objet'
    public class Bonhomme : Element
    {
        private static int compteur;
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
        }

        public void Tete()
        {
            dimensionFigure = new Point(100, 100);
            
            AjouterDisque("Tete", position, dimensionFigure, Color.Bisque);
        }

        public void BrasGauche()
        {
            dimensionFigure = new Point(40, 80);
            position.X += elements["Tete"].Dimension.X / 2 -
                          dimensionFigure.X / 2 + 5;
            position.Y += elements["Tete"].Dimension.Y + 40;
            AjouterEllipse("BrasGauche", position, dimensionFigure, Color.Brown, Color.Black, 1);
        }

        public void BrasDroit()
        {
            dimensionFigure = new Point(40, 80);
            position.X = elements["BrasGauche"].Position.X - 5;
            position.Y = elements["BrasGauche"].Position.Y;
            AjouterEllipse("BrasDroit", position, dimensionFigure, Color.Brown, Color.Black, 1);
            
            RotationFigure("BrasDroit", 60);
        }

        public void AvantBrasDroit()
        {
            dimensionFigure = new Point(40, 80);
            position = elements["BrasDroit"].PointAdjacent(Figure.Y);
            AjouterEllipse("AvantBrasDroit", position, dimensionFigure, Color.Brown, Color.Black, 1);
            
            AjustePosition("AvantBrasDroit", "BrasDroit");
            
            RotationFigure("AvantBrasDroit", 80);
        }
        
        public void Corps()
        {
            dimensionFigure = new Point(80, 160);
            
            position.X = elements["Tete"].Position.X + 5;
            position.Y = elements["Tete"].Position.Y +
                         elements["Tete"].Dimension.Y;
            
            AjouterEllipse("Corps", position, dimensionFigure, Color.Navy);
        }

        public void JambeGauche()
        {
            dimensionFigure = new Point(40, 80);
            position.X = elements["BrasGauche"].Position.X;
            position.Y = elements["Corps"].Position.Y +
                         elements["Corps"].Dimension.Y;
            AjouterEllipse("JambeGauche", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeGauche", 40);
        }

        public void GenouGauche()
        { 
            dimensionFigure = new Point(30, 30);
            position.X = elements["JambeGauche"].PointAdjacent(Figure.Y).X;
            position.Y = elements["JambeGauche"].PointAdjacent(Figure.Y).Y
                         - dimensionFigure.Y / 2;
            AjouterDisque("GenouGauche", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            
            AjustePosition("GenouGauche", "JambeGauche", position);
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
            dimensionFigure = new Point(40, 80);
            position = elements["JambeGauche"].PointAdjacent(Figure.Y);
            AjouterEllipse("JambeGaucheBas", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            
            AjustePosition("JambeGaucheBas", "JambeGauche", position);
        }

        public void JambeDroite()
        {
            position.X = elements["JambeGauche"].Position.X - 5;
            position.Y = elements["JambeGauche"].Position.Y - 15;
            AjouterEllipse("JambeDroite", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeDroite", -20);
        }
        
        public void GenouDroit()
        {
            dimensionFigure = new Point(30, 30);
            position.X = elements["JambeDroite"].PointAdjacent(Figure.Y).X;
            position.Y = elements["JambeDroite"].PointAdjacent(Figure.Y).Y
                         - dimensionFigure.Y / 2;
            AjouterDisque("GenouDroit", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            
            AjustePosition("GenouDroit", "JambeDroite", position);
        }

        public void JambeDroiteBas()
        {
            dimensionFigure = new Point(40, 80);
            position = elements["JambeDroite"].PointAdjacent(Figure.Y);
            AjouterEllipse("JambeDroiteBas", position, dimensionFigure, Color.CadetBlue, Color.Black, 1);
            RotationFigure("JambeDroiteBas", -40);
            
            AjustePosition("JambeDroiteBas", "JambeDroite", position);
        }

        public void PiedGauche()
        {
            dimensionFigure = new Point(70,30);
            position = elements["JambeGaucheBas"].PointAdjacent(Figure.Y);
            AjouterEllipse("PiedGauche", position, dimensionFigure, Color.Wheat, Color.Black, 1);
            
            AjustePosition("PiedGauche", "JambeGaucheBas", position);
        }

        public void PiedDroit()
        {
            position = elements["JambeDroiteBas"].PointAdjacent(Figure.Y);
            AjouterEllipse("PiedDroit", position, dimensionFigure, Color.Wheat, Color.Black, 1);
            
            AjustePosition("PiedDroit", "JambeDroiteBas", position);
        }
        
        public override string ToString()
        {
            compteur++;
            return "Bonhomme - " + compteur;
        }
    }
}