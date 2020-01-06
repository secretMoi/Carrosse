using System.Drawing;

namespace Carrosse.Elements
{
    public class Carabine : Element
    {
        public Carabine(Point positionConstructeur) : base(positionConstructeur)
        {
            // création gachette
            dimensionFigure = new Point(10, 10);
            AjouterArc("gachette", Color.Red, 3, 90, 180);
            
            // création anneau gachette
            dimensionFigure = new Point(30, 30);
            position.X = position.X - dimensionFigure.X / 2 
                         + elements["gachette"].Dimension.X / 2;
            position.Y -= (int)(elements["gachette"].Dimension.Y * 1.5);
            AjouterArc("anneauGachette", Color.Black, 3, 0, 180);

            // création corps
            dimensionFigure = new Point(150, 40);
            position.X -= dimensionFigure.X / 3;
            position.Y = elements["gachette"].Position.Y 
                         - dimensionFigure.Y;
            AjouterRectangle("corps", Color.Chocolate);

            // création canon
            dimensionFigure = new Point(150, 10);
            position.X += elements["corps"].Dimension.X;
            AjouterRectangle("canon", Color.Black);

            // création support lunette gauche
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         - 10;
            dimensionFigure.X = position.X;
            dimensionFigure.Y = position.Y - 15;
            AjouterLigne("supportLunetteGauche", Color.Black, 1);
            
            // création support lunette droite
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         + 10;
            dimensionFigure.X = position.X;
            AjouterLigne("supportLunetteDroite", Color.Black, 1);
            
            // création lunette
            dimensionFigure = new Point(40, 15);
            position.X = elements["supportLunetteGauche"].Dimension.X - 10;
            position.Y = elements["supportLunetteGauche"].Dimension.Y
                - dimensionFigure.Y;
            AjouterRectangle("lunette", Color.Black);
            
            // création entrée lunette
            dimensionFigure = new Point(8, 20);
            position.X -= dimensionFigure.X;
            position.Y -= (int)(dimensionFigure.Y - elements["lunette"].Dimension.Y) / 2;
            AjouterRectangle("entreeLunette", Color.Black);
            
            // création sortie lunette
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X;
            AjouterRectangle("sortieLunette", Color.Black);
            
            // création mollette lunette
            dimensionFigure = new Point(20, 8);
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2
                         - dimensionFigure.X / 2;
            position.Y = elements["lunette"].Position.Y
                         - dimensionFigure.Y;
            AjouterRectangle("molletteLunette", Color.Black);
            
            // création crosse
            dimensionFigure = new Point(100, 40);
            position.X = elements["corps"].Position.X 
                         - dimensionFigure.X + 8;
            position.Y = elements["corps"].Position.Y 
                         + dimensionFigure.Y - 6;
            AjouterRectangle("crosse", Color.Chocolate);
            elements["crosse"].Rotation.Position(20);
        }

        public override void Centre(ref Point point)
        {
            point.X -= dimensions.X / 2;
            point.Y -= dimensions.Y / 2;
        }
        
        public override string ToString()
        {
            return "Carabine";
        }
    }
}