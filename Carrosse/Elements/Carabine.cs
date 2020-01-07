using System.Drawing;

namespace Carrosse.Elements
{
    public class Carabine : Element
    {
        public Carabine(Point positionConstructeur) : base(positionConstructeur)
        {
            // création gachette
            dimensions = new Point(10, 10);
            AjouterArc("gachette", Color.Red, 3, 90, 180);
            
            // création anneau gachette
            dimensions = new Point(30, 30);
            position.X = position.X - dimensions.X / 2 
                         + elements["gachette"].Dimension.X / 2;
            position.Y -= (int)(elements["gachette"].Dimension.Y * 1.5);
            AjouterArc("anneauGachette", Color.Black, 3, 0, 180);

            // création corps
            dimensions = new Point(150, 40);
            position.X -= dimensions.X / 3;
            position.Y = elements["gachette"].Position.Y 
                         - dimensions.Y;
            AjouterRectangle("corps", Color.Chocolate);

            // création canon
            dimensions = new Point(150, 10);
            position.X += elements["corps"].Dimension.X;
            AjouterRectangle("canon", Color.Black);

            // création support lunette gauche
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         - 10;
            dimensions.X = position.X;
            dimensions.Y = position.Y - 15;
            AjouterLigne("supportLunetteGauche", Color.Black, 1);
            
            // création support lunette droite
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         + 10;
            dimensions.X = position.X;
            AjouterLigne("supportLunetteDroite", Color.Black, 1);
            
            // création lunette
            dimensions = new Point(40, 15);
            position.X = elements["supportLunetteGauche"].Dimension.X - 10;
            position.Y = elements["supportLunetteGauche"].Dimension.Y
                - dimensions.Y;
            AjouterRectangle("lunette", Color.Black);
            
            // création entrée lunette
            dimensions = new Point(8, 20);
            position.X -= dimensions.X;
            position.Y -= (int)(dimensions.Y - elements["lunette"].Dimension.Y) / 2;
            AjouterRectangle("entreeLunette", Color.Black);
            
            // création sortie lunette
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X;
            AjouterRectangle("sortieLunette", Color.Black);
            
            // création mollette lunette
            dimensions = new Point(20, 8);
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2
                         - dimensions.X / 2;
            position.Y = elements["lunette"].Position.Y
                         - dimensions.Y;
            AjouterRectangle("molletteLunette", Color.Black);
            
            // création crosse
            dimensions = new Point(100, 40);
            position.X = elements["corps"].Position.X 
                         - dimensions.X + 8;
            position.Y = elements["corps"].Position.Y 
                         + dimensions.Y - 6;
            AjouterRectangle("crosse", Color.Chocolate);
            elements["crosse"].Rotation.Position(20);
        }
    }
}