using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Carrosse.Animations;
using Carrosse.Figures;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private Animateur animateur;

        #region Initialisation

        public Form1()
        {
            InitializeComponent();

            Figure.InitialiseConteneur(pictureBox1);
            
            Text = "Accident aux Jeux-Olympiques!";
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
        }

        #region Controles déplacement

        #endregion
    }
}