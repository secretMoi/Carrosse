﻿using System;
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
            Carrosse.Deplace(e.Location);
            pictureBox1.Invalidate();
        }
        
        /*protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
                {
                case Keys.Up:
                    figureCourante.Bouger(0, -3);
                    break;
            
                case Keys.Down:
                    figureCourante.Bouger(0, 3);
                    break;
            
                case Keys.Left:
                    figureCourante.Bouger(-3);
                    break;
            
                case Keys.Right:
                    figureCourante.Bouger(3);
                    break;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }*/
        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Figure figure in Carrosse.ListeElements())
            {
                e.Graphics.DrawImage(figure.Image, figure.Position);
            }
        }
    }
}