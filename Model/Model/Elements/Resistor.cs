using System;
using System.Numerics;
using Model.Tools;

//См Inductor
namespace Model.Elements
{
    /// <summary>
    /// Класс резистор
    /// </summary>
    //TODO: Добавь модификатор доступа public к классам, которые будешь дергать из вне
    class Resistor : IElement
    {
        #region private members

        /// <summary>
        /// Переменная сопротивления
        /// </summary>
        private double _value;

        /// <summary>
        /// Переменная имени
        /// </summary>
        private string _name;

        #endregion

        /// <summary>
        /// События изменения сопротивления
        /// </summary>
        public event EventHandler ValueChanged;

        //TODO: Выбери для себя определенную последовательность методов, полей и свойств.
        /*  У тебя идет событие, потом идет свойство, потом 2 конструктора потом еще свойства...*/
        //TODO: Сделай регионы для свойств, конструкторов и методов, это относится к всем классам в Elements

        /// <summary>
        /// Тип элемента
        /// </summary>
        public ElementTypes Type => ElementTypes.Resistor;

        /// <summary>
        /// Пустой конструктор объекта катушки
        /// </summary>
        public Resistor():
            this(1, "Resistor #1.")
        {
        }

        /// <summary>
        /// Конструктор объекта катушки
        /// </summary>
        /// <param name="value"> Значение сопротивления </param>
        /// <param name="name"> Наименование элемента </param>
        public Resistor(double value, string name)
        {
            Validator.ValidateDouble(value);
            _value = value;
            Validator.ValidateString(name);
            _name = name;
        }

        /// <summary>
        /// Наименование элемента
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                Validator.ValidateString(value);
                _name = value;
            }
        }

        /// <summary>
        /// Сопротивление
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                Validator.ValidateDouble(value);
                _value = value;
                //TODO: Добавить условие, если value != _value тогда только вызывай событие
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Импеданс
        /// </summary>
        /// <param name="frequency"> Частота тока </param>
        public Complex CalculateZ(double frequency)
        {
            //TODO: Добавь валидацию
            return new Complex(Value, 0);
        }
    }
}
