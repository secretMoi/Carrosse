using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse.Animations
{
    public class Animateur
    {
        private Dictionary<string, Animation> Elements;
        // todo remplacer le timer par un multimedia timer, windows étant fort parallélisé, il n'est pas toujours occupé sur cette application et l interval est peut etre de 50ms
        private static System.Timers.Timer loopTimer;
        private const int INTERVAL_TIMER = 5;

        protected readonly PictureBox pictureBox;

        protected const bool ON = true;
        protected const bool OFF = false;
        public Animateur(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            
            Elements = new Dictionary<string, Animation>();
            
            SceneDepart();
        }
        
        private void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            foreach (Animation animation in Elements.Values)
            {
                animation.Anime();
            }
            
            pictureBox.Invalidate();
        }
        
        private void SetTimer(bool etat)
        {
            if (loopTimer == null)
            {
                loopTimer = new System.Timers.Timer();
                loopTimer.Interval = INTERVAL_TIMER; //interval in milliseconds
                loopTimer.Elapsed += loopTimerEvent; // à effectuer à toutes les intervalles
                loopTimer.AutoReset = true; // le ré enclenche à la fin
                
                Animation.SetPeriode(INTERVAL_TIMER);
            }
            
            loopTimer.Enabled = etat;
        }

        public void Affiche(Graphics graphics)
        {
            foreach (Element element in ListeElements())
            {
                element.Affiche(graphics);
            }
        }
        
        private List<Element> ListeElements()
        {
            List<Element> figures = new List<Element>();

            foreach (Animation animation in Elements.Values)
            {
                figures.Add(animation.Element);
            }

            return figures;
        }

        public void SceneDepart()
        {
            Elements.Add("carabine", new Carabine());
            Elements.Add("tireur", new Tireur(new Point(100, 100)));
            Elements["carabine"].Hydrate(Elements["tireur"].Element.GetFigure("AvantBrasDroit"));
            
            SetTimer(ON);
        }
    }
}