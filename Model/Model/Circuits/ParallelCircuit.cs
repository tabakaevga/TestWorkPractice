using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Model.Tools;
using Model;

namespace Model.Circuits
{
    class ParallelCircuit : ICircuit
    {
        private List<IComponent> _circuits;

        private string _name;

        public ParallelCircuit(List<IComponent> circuits )
        {
            _circuits = circuits;
        }

        public event EventHandler CircuitChanged;

        /// <summary>
        /// Наименование элемента
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                Validator.ValidateString(value);
                _name = value;
            }
        }


        public Complex CalculateZ(double frequency)
        {
            Complex mult = new Complex();
            Complex sum = new Complex();
            if (!_circuits.Any())
            {
                return new Complex(0,0);
            }
            foreach (IComponent component in _circuits)
            {
                mult *= component.CalculateZ(frequency);
                sum += component.CalculateZ(frequency);
            }
            return mult / sum;
        }

        public void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("Can't add null components.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) != null)
            {
                throw new ArgumentException("Component with this name already exists.");
            }
            _circuits.Add(component);
        }

        public void Remove(IComponent component)
        {
            if (!_circuits.Any())
            {
                throw new ArgumentNullException("Can't remove from empty list.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) == null)
            {
                throw new ArgumentException("Component with this name doesn't exist.");
            }
            _circuits.Remove(component);
        }

        private void OnCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        


    }
}
