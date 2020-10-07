using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maldelbrot_app
{
    public partial class Form1 : Form
    {
        private double hx, hy;
        private Bitmap bmp;
        private double sizeArea;

        private void button1_Click(object sender, EventArgs e)
        {
            Draw();
            timer1.Start();
        }


        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int X = e.X,
                Y = e.Y;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    hx = Fractal.temp(X, hx, sizeArea, pictureBox1.Width);
                    hy = Fractal.temp(Y, hy, sizeArea, pictureBox1.Height);
                    Draw();
                    break;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            sizeArea /= 1.1;
            Draw();
        }

        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bmp;

            sizeArea = 3;
        }

        private void Draw()
        {
            bmp = Fractal.createImage(sizeArea, pictureBox1.Height, pictureBox1.Width, hx, hy);
            pictureBox1.Image = bmp;
        }
    }
}
