using System.Numerics;

namespace Model
{
    //TODO: XML Комментарии
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
