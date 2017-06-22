﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface ICircuit : IComponent
    {
        /// <summary>
        /// Событие изменения контура
        /// </summary>
        event EventHandler CircuitChanged;
    }
}
