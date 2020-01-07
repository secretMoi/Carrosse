using System.Drawing;
using Carrosse.Elements;
using Carrosse.Figures;

namespace Carrosse.Animations
{
    public abstract class Animation
    {
        protected Element element; // élément couramment animé
        protected Point position; // position de l' élément couramment animé
        protected bool animationInitialisee; // vérifie que l'animation soit initialisée'
        protected Figure parente; // contient la figure parente pour les déplacements en chaine
        
        public Animation(Point position = default)
        {
            this.position = position;
            animationInitialisee = false;
        }

        // permet d'hydrater l'objet après le constructeur
        public virtual void Hydrate(params object[] parametre)
        {
        }

        // contient l'animation de l'élément
        public abstract void Anime();

        protected double Angle(string figure)
        {
            return element.GetFigure(figure).Rotation.AngleInverse();
        } 

        public Figure GetFigure(string nomFigure)
        {
            return element.GetFigure(nomFigure);
        }
        public Element Element => element;
    }
}