using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Carrosse.Elements;
using Timer = System.Timers.Timer;

namespace Carrosse.Animations
{
    public class Animateur
    {
        private Dictionary<string, Animation> Elements;
        // todo remplacer le timer par un multimedia timer, windows étant fort parallélisé, il n'est pas toujours occupé sur cette application et l interval est peut etre de 50ms
        private static Timer loopTimer;
        private static Timer timerReference;
        private const int INTERVAL_TIMER = 5;
        private long tempsProgramme;

        protected readonly PictureBox pictureBox;

        protected const bool ON = true;
        protected const bool OFF = false;
        public Animateur(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            
            Elements = new Dictionary<string, Animation>();
            
            SetTimerReference(95);
            
            SceneDepart();
        }
        
        private void LoopTimerEvent(Object source, ElapsedEventArgs e)
        {
            foreach (Animation animation in Elements.Values)
            {
                animation.Anime();
            }
            
            pictureBox.Invalidate();
            
            if(tempsProgramme >= 3000){}
                Debug.WriteLine("coucou");
        }
        
        private void TimerReferenceEvent(Object source, ElapsedEventArgs e)
        {
            tempsProgramme += (long)(timerReference.Interval + 5);
        }
        
        private void SetTimer(bool etat, int intervalle = INTERVAL_TIMER, bool autoReset = true)
        {
            if (loopTimer == null)
            {
                loopTimer = new Timer();
                loopTimer.Interval = intervalle; //interval in milliseconds
                loopTimer.Elapsed += LoopTimerEvent; // à effectuer à toutes les intervalles
                loopTimer.AutoReset = autoReset; // le ré enclenche à la fin
                
                Animation.SetPeriode(intervalle);
            }
            
            loopTimer.Enabled = etat;
        }
        
        private void SetTimerReference(int intervalle = INTERVAL_TIMER, bool autoReset = true)
        {
            timerReference = new Timer();
            timerReference.Interval = intervalle; //interval in milliseconds
            timerReference.Elapsed += TimerReferenceEvent; // à effectuer à toutes les intervalles
            timerReference.AutoReset = autoReset; // le ré enclenche à la fin

            timerReference.Enabled = true;
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

        public void Scene1()
        {
            Elements.Add("lunette", new Cible(new Point(300, 300)));
        }
    }
}