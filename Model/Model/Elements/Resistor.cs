using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Model.Tools;

namespace Model
{
    class Resistor : IElement
    {
        private double _value;
        private string _name;
        public event EventHandler ValueChanged;

        public Resistor()
        {
            _value = 1;
            _name = "Resistor #1.";
        }

        public Resistor(double value, string name)
        {
            Validator.ValidateDouble(_value);
            _value = value;
            Validator.ValidateString(name);
            _name = name;
        }

        public ElementTypes Type => ElementTypes.Resistor;

        public string Name
        {
            get { return _name; }
            set
            {
                Validator.ValidateString(value);
                _name = value;
            }
        }
        public double Value
        {
            get { return _value; }
            set
            {
                Validator.ValidateDouble(value);
                _value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        public Complex CalculateZ(double frequency)
        {
            return new Complex(Value, 0);
        }

        
    }
}
