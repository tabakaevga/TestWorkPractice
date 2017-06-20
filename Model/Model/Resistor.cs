using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Resistor : IElement
    {
        public event EventHandler ValueChanged;
        public Resistor(double value)
        {
            Value = value;

        }

        public ElementTypes Type => ElementTypes.Resistor;

        public double Value { get; set; }

        public Complex CalculateZ(double value)
        {
            return new Complex(Value, 0);
        }

        
    }
}
