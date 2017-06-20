using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Model.Tools;

namespace Model
{
    class Capacitor
    {
        private double _value;
        private string _name;

        public event EventHandler ValueChanged;
        public ElementTypes Type => ElementTypes.Resistor;

        public Capacitor()
        {
            _value = 1;
            _name = "Capacitor #1.";
        }

        public Capacitor(double value, string name)
        {
            Validator.ValidateDouble(_value);
            _value = value;
            Validator.ValidateString(name);
            _name = name;
        }

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
            Validator.ValidateDouble(frequency);
            return new Complex(0, - 1/ (Math.PI * frequency * _value));
        }
    }
}
