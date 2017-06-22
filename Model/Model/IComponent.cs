using System.Numerics;

namespace Model
{
    /// <summary>
    /// Интерфейс любых компонентов цепи
    /// </summary>
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
