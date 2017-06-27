using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Circuits;
using Model.Elements;

namespace View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            var f = new Form1(new SerialCircuit());
            f.ShowDialog();
        }

        private int index = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            SerialCircuit circuit = new SerialCircuit();
            circuit.CircuitChanged += circuit_OnCircuitChanged;
            circuit.Add(new Resistor(4, "R1"));
            ParallelCircuit p = new ParallelCircuit();
            p.CircuitChanged += circuit_OnCircuitChanged;
            p.Add(new Capacitor(0.000005, "C1"));
            p.Add(new Inductor(0.2, "L1"));
            circuit.Add(p);
            textBox1.Text = Convert.ToString(circuit.CalculateZ(50).Real) + '+' + Convert.ToString(circuit.CalculateZ(50).Imaginary);

        }

        private void circuit_OnCircuitChanged(object sender, EventArgs e)
        {
            button3.Text = Convert.ToString(index++);
        }
    }
}
