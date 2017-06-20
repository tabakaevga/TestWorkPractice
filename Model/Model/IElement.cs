using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Model
{
    //TODO: XML Комментарии
    interface IElement
    {
        //TODO: XML Комментарии
        ElementTypes Type { get; }

        //TODO: XML Комментарии
        string Name { get; set; }

        //TODO: XML Комментарии
        double Value { get; set; }

        //TODO: XML Комментарии
        Complex CalculateZ(double value);

        //TODO: XML Комментарии
        //TODO: У тебя в реализации событие находится выше чем рассчет Z. Мб тут тоже стоит поднять ? 
        event EventHandler ValueChanged;
    }
}
