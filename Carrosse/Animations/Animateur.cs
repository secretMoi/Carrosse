using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
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
        private static bool timerFini = true; // permet de savoir si le timer précédent à eu le temps de finir ses actions
        private static Timer timerReference; // timer qui coordonne les changements de scène
        private const int INTERVAL_TIMER = 5; // temps pour le timer par défaut
        private long tempsProgramme; // temps depuis le démarrage du programme, utilisé par le timer de référence
        private long tempsExpirationScene; // définit combien de temps une scène va s'exécuter
        private int numeroSceneSuivante;
        private bool nettoyeApresScene; // défini si les éléments de la scène seront supprimés ou pas

        protected readonly PictureBox pictureBox;

        protected const bool ON = true;
        protected const bool OFF = false;
        public Animateur(PictureBox pictureBox)
        {
            this.pictureBox = pictureBox;
            nettoyeApresScene = true;
            
            Elements = new Dictionary<string, Animation>();
            
            SetTimerReference(95);
            
            loopTimer = new Timer();
            
            SceneDepart();
        }
        
        // gère les actions de la scène courante
        private void LoopTimerEvent(Object source, ElapsedEventArgs e)
        {
            // si le timer précédent n'a pas fini ses actions
            if(timerFini == false)
                return;
            
            timerFini = false;
            
            foreach (Animation animation in Elements.Values)
            {
                animation.Anime();
            }
            
            pictureBox.Invalidate();

            FermeScene();

            timerFini = true;
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
            tempsExpirationScene = 0;
            
            Elements.Add("spectateur", new Spectateur(new Point(100, 100)));
            Elements.Add("kepi", new Kepi(new Point(100, 45)));
            Elements.Add("volcan", new Volcan(new Point(600, 130)));
            
            SetTimer(ON);
        }

        // tireur vue de profil
        public void Scene1()
        {
            tempsExpirationScene = 3000;
            
            Elements.Add("carabine", new Carabine());
            Elements.Add("tireur", new Tireur(new Point(100, 100)));
            Point positionCheveux = new Point();
            positionCheveux.X = Elements["tireur"].GetFigure("Tete").Position.X
                                - Elements["tireur"].GetFigure("Tete").Dimension.X / 2
                                - 10;
            positionCheveux.Y = (int) (
                                Elements["tireur"].GetFigure("Tete").Position.Y
                                - Elements["tireur"].GetFigure("Tete").Dimension.Y * 0.7
                            );
            Elements.Add("cheveux", new Cheveux(positionCheveux));
            Elements["carabine"].Hydrate(Elements["tireur"].GetFigure("AvantBrasDroit"));
            
            Son son = new Son("mmh");
            son.Joue();

            SetTimer(ON);
        }

        // vue lunette et cible
        public void Scene2()
        {
            tempsExpirationScene = 7700;

            Elements.Add("cible", new Cible(new Point(400, 300)));
            Elements.Add("lunette", new Lunette(new Point(300, 200)));
            
            Son son = new Son("breath");
            son.Joue();
            
            SetTimer(ON);

            nettoyeApresScene = false;
        }

        // éternuement
        public void Scene3()
        {
            tempsExpirationScene = 1000;
            
            Son son = new Son("sneeze");
            son.Joue();

            Elements["cible"].Hydrate(true);
            
            SetTimer(ON);
        }
        
        // tir après vue lunette
        public void Scene4()
        {
            tempsExpirationScene = 5000;
            
            Elements.Add("EffetBalle", new EffetBalle());
            Elements.Add("barney", new Barney(new Point(350, 30)));
            int xBalle = Elements["barney"].Element.Position("Personnage").X
                         + Elements["barney"].Element.Dimension("Image").X;
            Elements.Add("balle", new Balle(new Point(xBalle, 550)));
            Elements["EffetBalle"].Hydrate(
                Elements["balle"].Element.GetPosition.X + Elements["balle"].Element.GetDimension.X / 2 - 3,
                Elements["balle"].Element.GetPosition.Y
                );

            Son son = new Son("shot");
            son.Joue();
            
            SetTimer(ON);

            nettoyeApresScene = false;
        }
        
        // pause Oh NO
        public void Scene5()
        {
            tempsExpirationScene = 4000;
            
            Elements["barney"].Hydrate(false);

            Son son = new Son("oh_No");
            son.Joue();
            
            SetTimer(ON);
            
            nettoyeApresScene = false;
        }
        
        // reprise zoom
        public void Scene6()
        {
            tempsExpirationScene = 4000;
            
            Elements["barney"].Hydrate(true);

            Son son = new Son("reload");
            son.Joue();
            
            SetTimer(ON);
        }

        private void FermeScene()
        {
            // si le temps est expiré, sauf si le temps est illimité
            if (tempsProgramme >= tempsExpirationScene && tempsExpirationScene != 0)
            {
                SetTimer(OFF); // arrête le timer de scène

                if (nettoyeApresScene)
                {
                    Elements = new Dictionary<string, Animation>(); // vide la liste pour préparer la nouvelle scène
                }
                
                nettoyeApresScene = true;
                numeroSceneSuivante++;
                tempsProgramme = 0;

                // récupère le nom de la méthode dynamiquement
                MethodInfo method = GetType().GetMethod("Scene" + numeroSceneSuivante,
                    BindingFlags.Instance | BindingFlags.Public);
                method?.Invoke(this, null);
            }
        }
    }
}