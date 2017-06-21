using System;
using System.Numerics;
using Model.Tools;

namespace Model.Elements
{
    /// <summary>
    /// Класс 
    /// </summary>
    class Capacitor : IElement
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

        /// <summary>
        /// Тип элемента
        /// </summary>
        public ElementTypes Type => ElementTypes.Capacitor;

        /// <summary>
        /// Пустой конструктор объекта конденсатора
        /// </summary>
        public Capacitor():
            this(1,"Capacitor #1.")
        {
        }

        /// <summary>
        /// Конструктор объекта конденсатора
        /// </summary>
        /// <param name="value"> Значение сопротивления </param>
        /// <param name="name"> Наименование элемента </param>
        public Capacitor(double value, string name)
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
            return new Complex(0, - 1/ (Math.PI * frequency * _value));
        }
    }
}
