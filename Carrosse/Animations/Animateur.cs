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
        private static System.Timers.Timer loopTimer;
        private const int INTERVAL_TIMER = 15;

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
            Elements.Add("carabine", new Carabine(new Point(300, 250)));
            Elements.Add("tireur", new Tireur(new Point(100, 100)));
            
            SetTimer(ON);
        }
    }
}