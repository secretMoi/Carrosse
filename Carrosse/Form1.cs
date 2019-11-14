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
        public Form1()
        {
            InitializeComponent();
            
            Carrosse = new Carrosse(new Point(50, 100));
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
            button1.Text = e.Location.ToString();
            
            
        }
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in Carrosse.ListeElements())
            {
                e.Graphics.DrawImage(figure.Image, figure.Position);
            }
        }
    }
}