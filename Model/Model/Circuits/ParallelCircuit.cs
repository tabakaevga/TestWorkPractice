#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Elements;
using Model.Tools;

#endregion

namespace Model.Circuits
{
    /// <summary>
    ///     Параллельное соединение
    /// </summary>
    [Serializable]
    public class ParallelCircuit : Circuit
    {
        #region Public Methods

        /// <summary>
        ///     Импеданс
        /// </summary>
        /// <param name="frequency"> Частота </param>
        public override Complex CalculateZ(double frequency)
        {
            Validator.ValidateDouble(frequency);
            var sum = new Complex();
            if (!Circuits.Any())
                return new Complex(0, 0);
            foreach (var component in Circuits)
                sum += 1 / component.CalculateZ(frequency);
            return 1 / sum;
        }

        #endregion
    }
}