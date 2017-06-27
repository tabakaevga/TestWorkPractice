using System;
using Model.Elements;

namespace Model
{
    /// <summary>
    /// Интерфейс элементов цепи
    /// </summary>
    public interface IElement : IComponent
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
