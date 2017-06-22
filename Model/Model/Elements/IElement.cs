using System;

namespace Model
{
    /// <summary>
    /// Интерфейс элементов цепи
    /// </summary>
    interface IElement : IComponent
    {
        /// <summary>
        /// Событие изменения цепи
        /// </summary>
        event EventHandler ValueChanged;

        /// <summary>
        /// Тип элемента
        /// </summary>
        ElementTypes Type { get; }

        /// <summary>
        /// Значение сопротивления элемента
        /// </summary>
        double Value { get; set; }
    }
}
