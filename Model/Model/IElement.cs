using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Model
{
    /// <summary>
    /// Интерфейс элементов цепи
    /// </summary>
    interface IElement
    {
        /// <summary>
        /// Событие изменения сопротивления
        /// </summary>
        event EventHandler ValueChanged;

        /// <summary>
        /// Тип элемента
        /// </summary>
        ElementTypes Type { get; }

        /// <summary>
        /// Наименование элемента
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Значение сопротивления элемента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        /// Подсчет комплексного сопротивления элемента
        /// </summary>
        /// <param name="value"> Входящее значение (например, частота тока) </param>
        Complex CalculateZ(double value);
    }
}
