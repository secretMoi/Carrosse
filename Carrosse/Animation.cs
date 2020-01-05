using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Carrosse.Elements;

namespace Carrosse
{
    public class Animation
    {
        private Dictionary<string, Element> Elements;
        //private List<Element> Elements;
        private static System.Timers.Timer loopTimer;

        private readonly PictureBox pictureBox;
        private double angle = 0;

        private const bool ON = true;
        private const bool OFF = false;
        public Animation(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            
            Elements = new Dictionary<string, Element>();
            
            SceneDepart();
        }
        
        private void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            Elements["tireur"].GetFigure("corps").Rotation.SetRotation(90, 270);
            Elements["tireur"].GetFigure("corps").Rotation.Position(angle);
            angle++;
            
            pictureBox.Invalidate();
        }
        
        private void SetTimer(bool etat)
        {
            // timer qui se déclenche lorsque l'on clique dans la tv et sert à déplacer une figure
            if (loopTimer == null)
            {
                loopTimer = new System.Timers.Timer();
                loopTimer.Interval = 15; //interval in milliseconds
                
                loopTimer.Elapsed += loopTimerEvent; // à effectuer entre les 2 clics souris
                loopTimer.AutoReset = true; // le ré enclenche à la fin
            }
            
            loopTimer.Enabled = etat; // désactive par défaut pour limiter les ressources
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

            foreach (Element figure in Elements.Values)
            {
                figures.Add(figure);
            }

            return figures;
        }

        public void SceneDepart()
        {
            Elements.Add("carabine", new Carabine(new Point(300, 250)));
            Elements.Add("tireur", new Bonhomme(new Point(100, 100)));
            
            SetTimer(ON);
        }
    }
}