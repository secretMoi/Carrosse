using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using Carrosse.Elements;

namespace Carrosse
{
    public class Animation
    {
        private readonly List<Element> Elements;
        private static System.Timers.Timer loopTimer;
        public Animation()
        {
            Elements = new List<Element>();
            SceneDepart();
        }
        
        private void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            
        }
        
        private void SetTimer()
        {
            // timer qui se déclenche lorsque l'on clique dans la tv et sert à déplacer une figure
            loopTimer = new System.Timers.Timer();
            loopTimer.Interval = 15; //interval in milliseconds
            loopTimer.Enabled = true; // désactive par défaut pour limiter les ressources
            loopTimer.Elapsed += loopTimerEvent; // à effectuer entre les 2 clics souris
            loopTimer.AutoReset = true; // le ré enclenche à la fin
        }

        public void Affiche(Graphics graphics)
        {
            foreach (Element element in Elements)
            {
                element.Affiche(graphics);
            }
        }

        public void SceneDepart()
        {
            Elements.Add(new Carabine(new Point(300, 250)));
            Elements.Add(new Bonhomme(new Point(100, 100)));
            
        }
    }
}