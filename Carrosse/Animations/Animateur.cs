using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
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
        private static Timer loopTimer; // timer qui gère la scène courante
        private static Timer timerReference; // timer qui coordonne les changements de scène
        private const int INTERVAL_TIMER = 5; // temps pour le timer par défaut
        private long tempsProgramme; // temps depuis le démarrage du programme, utilisé par le timer de référence
        private long tempsExpirationScene; // définit combien de temps une scène va s'exécuter
        private int numeroSceneSuivante;

        protected readonly PictureBox pictureBox;

        protected const bool ON = true;
        protected const bool OFF = false;
        public Animateur(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            
            Elements = new Dictionary<string, Animation>();
            
            SetTimerReference(95);
            
            loopTimer = new Timer();
            
            SceneDepart();
        }
        
        // gère les actions de la scène courante
        private void LoopTimerEvent(Object source, ElapsedEventArgs e)
        {
            foreach (Animation animation in Elements.Values)
            {
                animation.Anime();
            }
            
            pictureBox.Invalidate();

            // si le temps est expière, sauf si le temps est illimité
            if (tempsProgramme >= tempsExpirationScene && tempsExpirationScene != 0)
            {
                SetTimer(OFF); // arrête le timer de scène
                Elements = new Dictionary<string, Animation>(); // vide la liste pour préparer la nouvelle scène
                numeroSceneSuivante++;
                tempsProgramme = 0;
                
                // récupère le nom de la méthode dynamiquement
                MethodInfo method = GetType().GetMethod("Scene" + numeroSceneSuivante,
                    BindingFlags.Instance | BindingFlags.Public);
                method?.Invoke(this, null);
            }
        }
        
        // actualise le temps du timer de référence
        private void TimerReferenceEvent(Object source, ElapsedEventArgs e)
        {
            tempsProgramme += (long)(timerReference.Interval + 5);
        }
        
        
        // initialise le timer de la scène courante
        private void SetTimer(bool etat, int intervalle = INTERVAL_TIMER, bool autoReset = true)
        {
            loopTimer.Interval = intervalle; //interval in milliseconds
            loopTimer.Enabled = etat;
            loopTimer.Elapsed += LoopTimerEvent; // à effectuer à toutes les intervalles
            loopTimer.AutoReset = autoReset; // le ré enclenche à la fin
            
            Animation.SetPeriode(intervalle);
        }
        
        // initialise le timer de référence
        private void SetTimerReference(int intervalle = INTERVAL_TIMER, bool autoReset = true)
        {
            timerReference = new Timer();
            timerReference.Interval = intervalle; //interval in milliseconds
            timerReference.Elapsed += TimerReferenceEvent; // à effectuer à toutes les intervalles
            timerReference.AutoReset = autoReset; // le ré enclenche à la fin

            timerReference.Enabled = true;
        }

        // affiche la scène et ses éléments
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
            tempsExpirationScene = 3000;
            tempsExpirationScene = 500;
            tempsExpirationScene = 0;
            
            /*Elements.Add("carabine", new Carabine());
            Elements.Add("tireur", new Tireur(new Point(100, 100)));
            Elements["carabine"].Hydrate(Elements["tireur"].Element.GetFigure("AvantBrasDroit"));*/
            
            Elements.Add("barney", new Barney(new Point(400, 30)));

            SetTimer(ON);
        }

        public void Scene1()
        {
            tempsExpirationScene = 7700;
            tempsExpirationScene = 500;

            Elements.Add("cible", new Cible(new Point(400, 300)));
            Elements.Add("lunette", new Lunette(new Point(300, 200)));
            
            Son son = new Son("breath");
            son.Joue();
            
            SetTimer(ON);
        }
        
        public void Scene2()
        {
            tempsExpirationScene = 0;
            
            Elements.Add("barney", new Barney(new Point(400, 30)));
            int xBalle = Elements["barney"].Element.Position("Personnage").X
                         + Elements["barney"].Element.Dimension("Image").X / 3;
            Elements.Add("balle", new Balle(new Point(xBalle, 550)));

            Son son = new Son("shot");
            son.Joue();
            
            SetTimer(ON);
        }
    }
}