using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Elements;
using Model.Tools;

namespace Model.Circuits
{
    /// <summary>
    ///     Параллельное соединение
    /// </summary>
    [Serializable]
    public class ParallelCircuit : ICircuit
    {
        #region Constructs

        /// <summary>
        ///     Конструктор параллельного соединения
        /// </summary>
        public ParallelCircuit()
        {
            _circuits = new List<IComponent>();
        }

        #endregion

        #region Events

        /// <summary>
        ///     Событие при изменении контура
        /// </summary>
        public event EventHandler CircuitChanged;

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
        /// Индексатор списка
        /// </summary>
        /// <param name="index"> Индекс </param>
        /// <returns></returns>
        public IComponent this[int index]
        {
            get { return _circuits[index]; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Object is not a component");
                }
                IComponent component = value;
                UnsubscribeFrom(_circuits[index]);
                _circuits[index] = component;
                SubscribeTo(_circuits[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion

        #region Private Fields

        /// <summary>
        ///     Список компонентов параллельного соединения
        /// </summary>
        private readonly List<IComponent> _circuits;

        /// <summary>
        ///     Наименование параллельного соединения
        /// </summary>
        private string _name;

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        ///     Перечисление компонентов
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IComponent> GetEnumerator()
        {
            return _circuits.GetEnumerator();
        }

        /// <summary>
        ///     Проверка на наличие объектов
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return _circuits.Any();
        }

        /// <summary>
        ///     Импеданс
        /// </summary>
        /// <param name="frequency"> Частота </param>
        public Complex CalculateZ(double frequency)
        {
            Validator.ValidateDouble(frequency);
            var sum = new Complex();
            if (!_circuits.Any())
                return new Complex(0, 0);
            foreach (var component in _circuits)
                sum += 1 / component.CalculateZ(frequency);
            return 1 / sum;
        }

        /// <summary>
        ///     Добавление компонента
        /// </summary>
        /// <param name="component"> Добавляемый компонент </param>
        public void Add(IComponent component)
        {
            if (component == null)
                throw new ArgumentException("Can't add null components.");
            if (FindComponent(component.Name) != null)
                throw new ArgumentException("Component with this name already exists.");
            _circuits.Add(component);
            OnCircuitChanged(this, new EventArgs());
            SubscribeTo(component);
        }

        /// <summary>
        ///     Удаление компонента
        /// </summary>
        /// <param name="component"> Удаляемый компонент </param>
        public void Remove(IComponent component)
        {
            if (!_circuits.Any())
                throw new ArgumentException("Can't remove from empty list.");
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) == null)
                throw new ArgumentException("Component with this name doesn't exist.");
            _circuits.Remove(component);
            OnCircuitChanged(this, new EventArgs());
            UnsubscribeFrom(component);
        }

        /// <summary>
        ///     Удаление компонента по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (!_circuits.Any())
                throw new ArgumentException("Can't remove from empty list.");
            index++;
            Validator.ValidateDouble(index);
            index--;
            var component = _circuits[index];
            _circuits.RemoveAt(index);
            OnCircuitChanged(this, new EventArgs());
            UnsubscribeFrom(component);
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Отписаться от компонента
        /// </summary>
        /// <param name="component">Компонент цепи </param>
        private void UnsubscribeFrom(IComponent component)
        {
            if (component is ICircuit)
            {
                var circuit = component as ICircuit;
                circuit.CircuitChanged -= CircuitChanged;
            }
            if (component is IElement)
            {
                var element = component as IElement;
                element.ValueChanged -= CircuitChanged;
            }
        }

        /// <summary>
        /// Поиск элементов
        /// </summary>
        /// <param name="name"> Имя элемента </param>
        /// <returns></returns>
        private IComponent FindComponent(string name)
        {
            return _circuits.FirstOrDefault(c => c.Name == name);
        }

        /// <summary>
        ///     Подписаться на компонент
        /// </summary>
        /// <param name="component">Компонент цепи </param>
        private void SubscribeTo(IComponent component)
        {
            if (component is ICircuit)
            {
                var circuit = component as ICircuit;
                circuit.CircuitChanged += CircuitChanged;
            }
            if (component is IElement)
            {
                var element = component as IElement;
                element.ValueChanged += CircuitChanged;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        ///     Метод события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected virtual void OnCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        #endregion

        #endregion
    }
}