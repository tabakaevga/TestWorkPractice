using System.Drawing;
using System.Windows.Forms;
using Model.Circuits;
using System.Drawing.Drawing2D;

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
            Graphics p = this.CreateGraphics();
            Pen myPen = new Pen(Color.Black)
            {
                Width = 4,
                StartCap = LineCap.RoundAnchor
            };
            p.DrawLine(myPen, 20, this.Height / 2, 50, this.Height / 2);
        }
    }
}
