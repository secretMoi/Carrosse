using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Carrosse.Figures;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private Carrosse Carrosse;
        private Bonhomme Bonhomme;
        private readonly List<Element> Elements;
        private Element elementCourant;
        private bool drag;

        #region Initialisation

        public Form1()
        {
            InitializeComponent();
            
            Elements = new List<Element>();
            drag = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        #endregion

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Element element in Elements)
            {
                // redessine toutes les parties des éléments
                foreach (Figure figure in element.ListeElements())
                {
                    e.Graphics.DrawImage(figure.Image, figure.Position);
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
            
            /*(Elements[elementCourant] as Bonhomme).Rotation();
            pictureBox1.Invalidate();*/

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
    }
}