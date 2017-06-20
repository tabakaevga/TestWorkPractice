using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Model
{
    interface IElement
    {
        ElementTypes Type { get; }

        string Name { get; set; }

        double Value { get; set; }

        Complex CalculateZ(double value);

        event EventHandler ValueChanged;
    }
}
