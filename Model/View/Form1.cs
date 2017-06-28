using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Model.Circuits;

namespace View
{
    public partial class Form1 : Form
    {
        public Form1(SerialCircuit circuit)
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            var p = CreateGraphics();
            var myPen = new Pen(Color.Black)
            {
                Width = 4,
                StartCap = LineCap.RoundAnchor
            };
            p.DrawLine(myPen, 20, Height / 2, 50, Height / 2);
        }
    }
}