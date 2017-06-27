using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Model.Tools;
using Model;

namespace Model.Circuits
{
    /// <summary>
    /// Параллельное соединение
    /// </summary>
    public class ParallelCircuit : ICircuit
    {

        #region Private Fields

        /// <summary>
        /// Список компонентов параллельного соединения
        /// </summary>
        private readonly List<IComponent> _circuits;

        /// <summary>
        /// Наименование параллельного соединения
        /// </summary>
        private string _name;

        #endregion

        #region Events

        /// <summary>
        /// Событие при изменении контура
        /// </summary>
        public event EventHandler CircuitChanged;

        #endregion

        #region Constructs

        /// <summary>
        /// Конструктор параллельного соединения
        /// </summary>
        public ParallelCircuit()
        {

            _circuits = new List<IComponent>();
        }

        #endregion

        #region Properties

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

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Импеданс
        /// </summary>
        /// <param name="frequency"> Частота </param>
        public Complex CalculateZ(double frequency)
        {
            Validator.ValidateDouble(frequency);
            Complex sum = new Complex();
            if (!_circuits.Any())
            {
                return new Complex(0, 0);
            }
            foreach (IComponent component in _circuits)
            {
                
                sum += 1 / component.CalculateZ(frequency);
            }
            return 1 / sum;
        }

        /// <summary>
        /// Добавление компонента
        /// </summary>
        /// <param name="component"> Добавляемый компонент </param>
        public void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentException("Can't add null components.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) != null)
            {
                throw new ArgumentException("Component with this name already exists.");
            }
            _circuits.Add(component);
            OnCircuitChanged(this, new EventArgs());
            SubscribeTo(component);
        }

        /// <summary>
        /// Удаление компонента
        /// </summary>
        /// <param name="component"> Удаляемый компонент </param>
        public void Remove(IComponent component)
        {
            if (!_circuits.Any())
            {
                throw new ArgumentException("Can't remove from empty list.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) == null)
            {
                throw new ArgumentException("Component with this name doesn't exist.");
            }
            _circuits.Remove(component);
            OnCircuitChanged(this, new EventArgs());
            UnsubscribeFrom(component);
        }
            
        /// <summary>
        /// Удаление компонента по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (!_circuits.Any())
            {
                throw new ArgumentException("Can't remove from empty list.");
            }
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
        /// Отписаться от компонента
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
        /// Подписаться на компонент
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
        /// Метод события
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
