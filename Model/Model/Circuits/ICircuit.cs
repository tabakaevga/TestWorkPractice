using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Контур цепи/Соединение
    /// </summary>
    interface ICircuit : IComponent
    {
        /// <summary>
        /// Событие изменения контура
        /// </summary>
        event EventHandler CircuitChanged;
    }
}
