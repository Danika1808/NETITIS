using System;
using System.Drawing;
using System.Windows.Forms;

namespace Maldelbrot_app
{
    public partial class Form1 : Form
    {
        private double _hx, _hy;
        private Bitmap _bmp;
        private double _sizeArea = 3;
        private readonly double _zoom = 1.1;

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
                    _hx = Fractal.temp(X, _hx, _sizeArea, pictureBox1.Width);
                    _hy = Fractal.temp(Y, _hy, _sizeArea, pictureBox1.Height);
                    Draw();
                    break;
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            _sizeArea /= _zoom;
            Draw();
        }

        public Form1()
        {
            InitializeComponent();

            _bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = _bmp;
        }

        private void Draw()
        {
            _bmp = Fractal.createImage(_sizeArea, pictureBox1.Height, pictureBox1.Width, _hx, _hy);
            pictureBox1.Image = _bmp;
        }
    }
}
