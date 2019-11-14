using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carrosse.Figures;
using Rectangle = Carrosse.Figures.Rectangle;

namespace Carrosse
{
    public partial class Form1 : Form
    {
        private Carrosse Carrosse;
        private bool drag;
        public Form1()
        {
            InitializeComponent();
            
            Carrosse = new Carrosse(new Point(50, 100));
            drag = false;
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(!drag) return;
            Carrosse.Deplace(e.Location);
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
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in Carrosse.ListeElements())
            {
                e.Graphics.DrawImage(figure.Image, figure.Position);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }
}