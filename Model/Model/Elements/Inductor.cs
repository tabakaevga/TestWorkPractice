using System;
using System.Numerics;
using Model.Tools;

namespace Model.Elements
{
    /// <summary>
    ///     Класс Катушка
    /// </summary>
    [Serializable]
    public class Inductor : IElement
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
            return new Complex(0, 2 * Math.PI * frequency * _value);
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
        public Inductor() :
            this(1, "Inductor #1.")
        {
        }

        /// <summary>
        ///     Конструктор объекта катушки
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
                if (Math.Abs(value - _value) > 0.0000000000000000000000000000000001)
                {
                    _value = value;
                    ValueChanged?.Invoke(this, new EventArgs());
                }
                    
            }
        }

        #endregion
    }
}