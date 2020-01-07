using System;
using System.Drawing;

namespace Carrosse.Elements
{
    public class Arbre : RessourceImage
    {
        private int nombre;
        public Arbre(Point position) : base(position)
        {
            Random aleatoire = new Random();
            nombre = aleatoire.Next(1, 7); // Génère un entier compris entre 1 et 6
            nomFichier = "arbre-" + nombre + ".png";

            dimensions.X = 70;
            
            ChargeImage();
        }
    }
}