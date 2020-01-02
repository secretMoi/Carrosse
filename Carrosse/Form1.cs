using System;
using System.Collections.Generic;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Carrosse.Figures;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private readonly List<Element> Elements;
        private Element elementCourant;
        private bool drag;
        
        private static System.Timers.Timer loopTimer;

        #region Initialisation

        public Form1()
        {
            InitializeComponent();
            
            Elements = new List<Element>();
            drag = false;
            
            Figure.InitialiseConteneur(pictureBox1);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #endregion
        
        private void loopTimerEvent(Object source, ElapsedEventArgs e)
        {
            /*Elements[0].ListeElements()[2].Rotation(45);
            
            pictureBox1.Invalidate();*/
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element element in Elements)
            {
                // redessine toutes les parties des éléments
                foreach (Figure figure in element.ListeElements())
                {
                    //figure.Rotation(10);
                    figure.Afficher(e.Graphics);
                }
            }
        }

        #region Controles déplacement

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
        
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!drag) return; // si le drag&drop n'est pas activé on ne fait rien

            Point positionCourante = e.Location;
            elementCourant.Centre(ref positionCourante);
            elementCourant.Deplace(positionCourante);
            
            pictureBox1.Invalidate();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    elementCourant.Deplace(0, -3);
                    break;
            
                case Keys.Down:
                    elementCourant.Deplace(0, 3);
                    break;
            
                case Keys.Left:
                    elementCourant.Deplace(-3);
                    break;
            
                case Keys.Right:
                    elementCourant.Deplace(3);
                    break;
            }

            pictureBox1.Invalidate();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
            Elements.Add(new Carrosse(new Point(50, 100)));
            elementCourant = Elements[Elements.Count - 1] as Carrosse;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Elements.Add(new Bonhomme(new Point(50, 100)));
            elementCourant = Elements[Elements.Count - 1] as Bonhomme;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            SetTimer();
            
            pictureBox1.Invalidate();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            elementCourant = Elements[listBox1.SelectedIndex];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Elements.Add(new TestPolygone(new Point(50, 100)));
            elementCourant = Elements[Elements.Count - 1] as TestPolygone;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
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
    }
}