using System.Drawing;

namespace Carrosse.Elements
{
    public class Carabine : Element
    {
        public Carabine(Point position) : base(position)
        {
            // création gachette
            Point dimension = new Point(10, 10);
            AjouterArc("gachette", position, dimension, Color.Red, 3, 90, 180);
            
            // création anneau gachette
            dimension = new Point(30, 30);
            position.X = position.X - dimension.X / 2 
                         + elements["gachette"].Dimension.X / 2;
            position.Y -= (int)(elements["gachette"].Dimension.Y * 1.5);
            AjouterArc("anneauGachette", position, dimension, Color.Black, 3, 0, 180);

            // création corps
            dimension = new Point(150, 40);
            position.X -= dimension.X / 3;
            position.Y = elements["gachette"].Position.Y 
                         - dimension.Y;
            AjouterRectangle("corps", position, dimension, Color.Chocolate);

            // création canon
            dimension = new Point(150, 10);
            position.X += elements["corps"].Dimension.X;
            AjouterRectangle("canon", position, dimension, Color.Black);
            
            elements["canon"].Tourne(180);

            Point testPos;
            testPos = elements["canon"].Fin();
            AjouterRectangle("test", testPos, new Point(10,10), Color.Red);

            // création support lunette gauche
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         - 10;
            dimension.X = position.X;
            dimension.Y = position.Y - 15;
            AjouterLigne("supportLunetteGauche", position, dimension, Color.Black, 1);
            
            // création support lunette droite
            position.X = elements["corps"].Position.X
                         + elements["corps"].Dimension.X / 2
                         + 10;
            dimension.X = position.X;
            AjouterLigne("supportLunetteDroite", position, dimension, Color.Black, 1);
            
            // création lunette
            dimension = new Point(40, 15);
            position.X = elements["supportLunetteGauche"].Dimension.X - 10;
            position.Y = elements["supportLunetteGauche"].Dimension.Y
                - dimension.Y;
            AjouterRectangle("lunette", position, dimension, Color.Black);
            
            // création entrée lunette
            dimension = new Point(8, 20);
            position.X -= dimension.X;
            position.Y -= (int)(dimension.Y - elements["lunette"].Dimension.Y) / 2;
            AjouterRectangle("entreeLunette", position, dimension, Color.Black);
            
            // création sortie lunette
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X;
            AjouterRectangle("sortieLunette", position, dimension, Color.Black);
            
            // création mollette lunette
            dimension = new Point(20, 8);
            position.X = elements["lunette"].Position.X
                         + elements["lunette"].Dimension.X / 2
                         - dimension.X / 2;
            position.Y = elements["lunette"].Position.Y
                         - dimension.Y;
            AjouterRectangle("molletteLunette", position, dimension, Color.Black);
            
            // création crosse
            dimension = new Point(100, 40);
            position.X = elements["corps"].Position.X 
                         - dimension.X + 8;
            position.Y = elements["corps"].Position.Y 
                         + dimension.Y - 6;
            AjouterRectangle("crosse", position, dimension, Color.Chocolate);
            elements["crosse"].Rotation(20);
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