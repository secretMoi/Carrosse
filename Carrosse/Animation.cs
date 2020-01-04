using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse
{
    public class Animation
    {
        private readonly List<Element> Elements;
        private static System.Timers.Timer loopTimer;

        private readonly PictureBox pictureBox;

        private const bool ON = true;
        private const bool OFF = false;
        public Animation(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            
            Elements = new List<Element>();
            
            SceneDepart();
        }
        
        private void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            Elements[1].GetFigure("jambeD").Tourne(1);
            pictureBox.Invalidate();
        }
        
        private void SetTimer(bool etat)
        {
            // timer qui se déclenche lorsque l'on clique dans la tv et sert à déplacer une figure
            loopTimer = new System.Timers.Timer();
            loopTimer.Interval = 15; //interval in milliseconds
            loopTimer.Enabled = etat; // désactive par défaut pour limiter les ressources
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
            
            SetTimer(ON);
        }
    }
}