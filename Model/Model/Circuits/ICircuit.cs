using System;

namespace Model.Circuits
{
    /// <summary>
    ///     Контур цепи/Соединение
    /// </summary>
    public interface ICircuit : IComponent
    {
        /// <summary>
        ///     Событие изменения контура
        /// </summary>
        event EventHandler CircuitChanged;
    }
}