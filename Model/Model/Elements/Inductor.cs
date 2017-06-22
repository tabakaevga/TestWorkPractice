using System;
using System.Numerics;
using Model.Tools;


namespace Model.Elements 
{
    /// <summary>
    /// Класс Катушка
    /// </summary>
    class Inductor : IElement
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

        //TODO: Добавь регионы (описано в Resistor)

        //NOTE: См. Capacitor
        /// <summary>
        /// Тип элемента
        /// </summary>
        public ElementTypes Type => ElementTypes.Inductor;

        /// <summary>
        /// Пустой конструктор объекта катушки
        /// </summary>
        public Inductor() :
            this(1, "Inductor #1.")
        {
        }

        /// <summary>
        /// Конструктор объекта катушки
        /// </summary>
        /// <param name="value"> Значение сопротивления </param>
        /// <param name="name"> Наименование элемента </param>
        public Inductor(double value, string name)
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
            //NOTE: В таких конструкциях можно лямбду исползовать
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
                //TODO: Проверка описана в Resistor
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        /// <summary>
        /// Импеданс
        /// </summary>
        /// <param name="frequency"> Частота тока </param>
        public Complex CalculateZ(double frequency)
        {
            Validator.ValidateDouble(frequency);
            return new Complex(0, 2 * Math.PI * frequency * _value);
        }
    }
}
