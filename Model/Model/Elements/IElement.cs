using System;

namespace Model.Elements
{
    /// <summary>
    ///     Интерфейс элементов цепи
    /// </summary>
    public interface IElement : IComponent
    {
        /// <summary>
        ///     Значение сопротивления элемента
        /// </summary>
        double Value { get; set; }

        /// <summary>
        ///     Событие изменения цепи
        /// </summary>
        event EventHandler ValueChanged;
    }
}