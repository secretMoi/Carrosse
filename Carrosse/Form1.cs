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
        private List<Figure> figures;
        public Form1()
        {
            InitializeComponent();
            figures = new List<Figure>();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(500,500);
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in figures)
            {
                e.Graphics.DrawImage(figure.Image, figure.Position);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            figures = new List<Figure>();
            
            figures.Add(new Rectangle(new Point(70, 70), new Point(50,50),  Color.Red));
            figures.Add(new Rectangle(new Point(200, 200), new Point(50,50),  Color.Navy));
            
            figures.Add(new Cercle(new Point(100, 100), 40,  Color.Brown));
            
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.Text = e.Location.ToString();
        }
    }
}