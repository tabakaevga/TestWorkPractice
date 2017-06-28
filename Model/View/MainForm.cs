using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Model.Circuits;
using View.CircuitForms;
using View.Tools;

namespace View
{
    public partial class MainForm : Form
    {
        private List<IComponent> _circuitList;

        public MainForm()
        {
            _circuitList = new List<IComponent>();
            InitializeComponent();
        }

        private void RefillList()
        {
            CircuitsList.Items.Clear();
            foreach (IComponent component in _circuitList)
            {
                CircuitsList.Items.Add(component.Name);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializer.SerializeBinary(saveFileDialog1.FileName, ref _circuitList);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Serializer.DeserializeBinary(openFileDialog1.FileName, ref _circuitList);
        }

        private void AddCircuit_Click(object sender, EventArgs e)
        {
            var f = new SerialCircuitEditor();
            f.ShowDialog();
            if (f.CircuitSent != null)
            {
                _circuitList.Add(f.CircuitSent);
            }
            RefillList();
        }

        private void CircuitsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = CircuitsList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var f = new SerialCircuitEditor(_circuitList[index] as SerialCircuit);
                f.ShowDialog();
                if (f.CircuitSent != null)
                {
                    _circuitList[index] = f.CircuitSent;
                    RefillList();
                }
            }
        }

        private void RemoveCircuit_Click(object sender, EventArgs e)
        {
            _circuitList.RemoveAt(CircuitsList.SelectedIndex);
            RefillList();
        }
    }
}