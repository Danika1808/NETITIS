using System.Drawing;
using System.Windows.Forms;

namespace Maldelbrot_app
{
    public partial class Form1 : Form
    {
        Bitmap newBitmap;
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            var iterations = 1;
            pictureBox1.Image= Fractal.createImage(1.5, -1.5, -1.5, 1);
        }

    }
}
