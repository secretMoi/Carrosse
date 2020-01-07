using System.Drawing;

namespace Carrosse.Elements
{
    public class Lunette : Element
    {
        public Lunette(Point positionConstrcuteur) : base(positionConstrcuteur)
        {
            // création cercle CercleExterieur
            CercleExterieur();
            
            CercleInterieur();
            
            // création mollette gauche
            MolletteGauche();
            
            // création mollette droite
            MolletteDroite();
            
            // création mollette haut
            MolletteHaut();
            
            // création ligne verticale
            LigneVerticale();
            
            // création ligne horizontale
            LigneHorizontale();
            
            RectangleGauche();
            RectangleDroit();
            RectangleHaut();
            RectangleBas();
        }

        public void CercleExterieur()
        {
            Dimensionne(400,400);
            AjouterCercle("CercleExterieur", Color.Black, 15);
        }
        
        public void CercleInterieur()
        {
            Dimensionne(
                elements["CercleExterieur"].Dimension.X / 2, 
                elements["CercleExterieur"].Dimension.Y / 2
            );
            position.X = elements["CercleExterieur"].Position.X
                         + elements["CercleExterieur"].Dimension.X / 4;
            position.Y = elements["CercleExterieur"].Position.Y
                         + elements["CercleExterieur"].Dimension.Y/ 4;
            AjouterCercle("CercleInterieur", Color.Black);
        }
        
        public void MolletteGauche()
        {
            Dimensionne(50,100);
            position.X = elements["CercleExterieur"].Position.X 
                         - dimensions.X;
            position.Y = elements["CercleExterieur"].Position.Y
                         + elements["CercleExterieur"].Dimension.Y / 2
                         - dimensions.Y / 2;
            AjouterRectangle("MolletteGauche", Color.Black);
        }
        
        public void MolletteDroite()
        {
            Dimensionne(50,100);
            position.X = elements["MolletteGauche"].Position.X
                         + elements["CercleExterieur"].Dimension.X
                         + dimensions.X;
            position.Y = elements["CercleExterieur"].Position.Y
                         + elements["CercleExterieur"].Dimension.Y / 2
                         - dimensions.Y / 2;
            AjouterRectangle("MolletteDroite", Color.Black);
        }

        public void MolletteHaut()
        {
            Dimensionne(100, 50);
            position.X = elements["CercleExterieur"].Position.X
                         + elements["CercleExterieur"].Dimension.X / 2
                         - dimensions.X / 2;
            position.Y = elements["CercleExterieur"].Position.Y
                         - dimensions.Y;
            AjouterRectangle("MolletteHaut", Color.Black);
        }

        public void LigneVerticale()
        {
            position.X = elements["CercleExterieur"].Position.X
                         + elements["CercleExterieur"].Dimension.X / 2;
            position.Y = elements["CercleExterieur"].Position.Y;
            dimensions.X = position.X;
            dimensions.Y = position.Y + elements["CercleExterieur"].Dimension.Y;
            AjouterLigne("LigneVerticale", Color.Black, 2);
        }
        
        public void LigneHorizontale()
        {
            position.X = elements["CercleExterieur"].Position.X;
            position.Y = elements["CercleExterieur"].Position.Y
                         + elements["CercleExterieur"].Dimension.Y / 2;
            dimensions.X = position.X + elements["CercleExterieur"].Dimension.X;
            dimensions.Y = position.Y;
            AjouterLigne("LigneHorizontale", Color.Black, 2);
        }
        
        public void RectangleGauche()
        {
            Dimensionne(
                elements["LigneHorizontale"].Dimension.X / 5,
                12
            );
            position.X = elements["LigneHorizontale"].Position.X;
            position.Y = elements["LigneHorizontale"].Position.Y
                         - dimensions.Y / 2;
            AjouterRectangle("RectangleGauche", Color.Black);
        }
        
        public void RectangleDroit()
        {
            Dimensionne(
                elements["RectangleGauche"].Dimension.X,
                elements["RectangleGauche"].Dimension.Y
            );
            position.X = elements["CercleExterieur"].Position.X
                         + elements["CercleExterieur"].Dimension.X
                         - dimensions.X;
            position.Y = elements["RectangleGauche"].Position.Y;
            AjouterRectangle("RectangleDroit", Color.Black);
        }
        
        public void RectangleHaut()
        {
            Dimensionne(
                elements["RectangleGauche"].Dimension.Y,
                elements["RectangleGauche"].Dimension.X
            );
            position.X = elements["CercleExterieur"].Position.X
                         + elements["CercleExterieur"].Dimension.X / 2
                         - dimensions.X / 2;
            position.Y = elements["CercleExterieur"].Position.Y;
            AjouterRectangle("RectangleHaut", Color.Black);
        }
        
        public void RectangleBas()
        {
            Dimensionne(
                elements["RectangleGauche"].Dimension.Y,
                elements["RectangleGauche"].Dimension.X
            );
            position.X = elements["RectangleHaut"].Position.X;
            position.Y = elements["CercleExterieur"].Position.Y
                         + elements["CercleExterieur"].Dimension.Y
                         - dimensions.Y;
            AjouterRectangle("RectangleBas", Color.Black);
        }
    }
}