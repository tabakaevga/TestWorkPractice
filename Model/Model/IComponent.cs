using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IComponent
    {
        /// <summary>
        /// Наименование компонента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Подсчет комплексного сопротивления компонента
        /// </summary>
        /// <param name="value"> Входящее значение (например, частота тока) </param>
        Complex CalculateZ(double value);
    }
}
