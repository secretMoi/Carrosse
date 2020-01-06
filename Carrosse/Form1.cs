using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Carrosse.Animations;
using Carrosse.Elements;
using Carrosse.Figures;
using Balle = Carrosse.Elements.Balle;
using Carabine = Carrosse.Elements.Carabine;
using Cible = Carrosse.Elements.Cible;
using Lunette = Carrosse.Elements.Lunette;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private readonly List<Element> Elements;
        private Element elementCourant;
        private bool drag;

        private Animateur animateur;

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
            animateur = new Animateur(pictureBox1);
        }

        #endregion

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // lisse les contours
            
            animateur.Affiche(e.Graphics);
            
            foreach (Element element in Elements)
            {
                element.Affiche(e.Graphics);
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
            if (Elements.Count < 1) return; // vérifie qu'il y a bien des éléments à déplacer

            Point positionCourante = e.Location;
            elementCourant.Centre(ref positionCourante);
            elementCourant.Deplace(positionCourante);
            
            pictureBox1.Invalidate();
        }

        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
           
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
            Elements.Add(new Lunette(new Point(0, 0)));
            elementCourant = Elements[Elements.Count - 1] as Lunette;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }

        private void Cible_Click(object sender, EventArgs e)
        {
            Elements.Add(new Cible(new Point(0, 0)));
            elementCourant = Elements[Elements.Count - 1] as Cible;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Elements.Add(new Balle(new Point(0, 0)));
            elementCourant = Elements[Elements.Count - 1] as Balle;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Elements.Add(new Carabine(new Point(0, 0)));
            elementCourant = Elements[Elements.Count - 1] as Carabine;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Elements.Add(new Arbre(new Point(0, 0)));
            elementCourant = Elements[Elements.Count - 1] as Arbre;
            listBox1.Items.Add(elementCourant.ToString()); // ajoute la figure dans la listbox
            
            pictureBox1.Invalidate();
        }
    }
}