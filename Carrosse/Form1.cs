using System;
using System.Drawing;
using System.Windows.Forms;
using Carrosse.Figures;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private readonly Carrosse Carrosse;
        private bool drag;

        #region Initialisation

        public Form1()
        {
            InitializeComponent();
            
            Carrosse = new Carrosse(new Point(50, 100));
            drag = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // redessine toutes les parties du carrosse
            foreach (Figure figure in Carrosse.ListeElements())
            {
                e.Graphics.DrawImage(figure.Image, figure.Position);
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
            Carrosse.Centre(ref positionCourante);
            Carrosse.Deplace(positionCourante);
            
            pictureBox1.Invalidate();
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    Carrosse.Deplace(0, -3);
                    break;
            
                case Keys.Down:
                    Carrosse.Deplace(0, 3);
                    break;
            
                case Keys.Left:
                    Carrosse.Deplace(-3);
                    break;
            
                case Keys.Right:
                    Carrosse.Deplace(3);
                    break;
            }

            pictureBox1.Invalidate();

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }
}