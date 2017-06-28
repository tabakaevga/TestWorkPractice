using System;
using System.Numerics;
using Model.Tools;

//См Inductor

namespace Model.Elements
{
    /// <summary>
    ///     Класс резистор
    /// </summary>
    [Serializable]
    public class Resistor : IElement
    {
        #region Events

        /// <summary>
        ///     События изменения сопротивления
        /// </summary>
        public event EventHandler ValueChanged;

        #endregion

        #region Methods

        /// <summary>
        ///     Импеданс
        /// </summary>
        /// <param name="frequency"> Частота тока </param>
        public Complex CalculateZ(double frequency)
        {
            Validator.ValidateDouble(frequency);
            return new Complex(Value, 0);
        }

        #endregion

        #region private members

        /// <summary>
        ///     Переменная сопротивления
        /// </summary>
        private double _value;

        /// <summary>
        ///     Переменная имени
        /// </summary>
        private string _name;

        #endregion

        #region Constructs

        /// <summary>
        ///     Пустой конструктор объекта катушки
        /// </summary>
        public Resistor() :
            this(1, "Resistor #1.")
        {
        }

        /// <summary>
        ///     Конструктор объекта катушки
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

        #endregion

        #region Properties

        /// <summary>
        ///     Наименование элемента
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
        ///     Сопротивление
        /// </summary>
        public double Value
        {
            get { return _value; }
            set
            {
                Validator.ValidateDouble(value);
                _value = value;
                if (Math.Abs(value - _value) > 0.0000000000000000000000000000000001)
                    ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion
    }
}