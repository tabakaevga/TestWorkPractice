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
    class ParallelCircuit : ICircuit
    {
        //TODO: Регионы (см. Resistor)
        /// <summary>
        /// Список компонентов параллельного соединения
        /// </summary>
        private List<IComponent> _circuits;

        /// <summary>
        /// Наименование параллельного соединения
        /// </summary>
        private string _name;

        /// <summary>
        /// Конструктор параллельного соединения
        /// </summary>
        /// <param name="circuits"></param>
        //TODO: опиши параметр
        public ParallelCircuit(List<IComponent> circuits )
        {
            //TODO: Нужна проверка на Null
            _circuits = circuits;
        }

        /// <summary>
        /// Событие при изменении контура
        /// </summary>
        public event EventHandler CircuitChanged;

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
        /// Импеданс
        /// </summary>
        /// <param name="frequency"> Частота </param>
        /// <returns></returns>
        public Complex CalculateZ(double frequency)
        {
            //NOTE: лол, один в один моя реализация)
            Complex mult = new Complex();
            Complex sum = new Complex();
            if (!_circuits.Any())
            {
                return new Complex(0,0);
            }
            foreach (IComponent component in _circuits)
            {
                mult *= component.CalculateZ(frequency);
                sum += component.CalculateZ(frequency);
            }
            return mult / sum;
        }

        /// <summary>
        /// Добавление компонента
        /// </summary>
        /// <param name="component"></param>
        //TODO: Опиши аргумент
        public void Add(IComponent component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("Can't add null components.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) != null)
            {
                throw new ArgumentException("Component with this name already exists.");
            }
            _circuits.Add(component);
        }

        /// <summary>
        /// Удаление компонента
        /// </summary>
        /// <param name="component"></param>
        //TODO: Опиши аргумент
        public void Remove(IComponent component)
        {
            if (!_circuits.Any())
            {
                throw new ArgumentNullException("Can't remove from empty list.");
            }
            if (_circuits.FirstOrDefault(c => c.Name == component.Name) == null)
            {
                throw new ArgumentException("Component with this name doesn't exist.");
            }
            _circuits.Remove(component);
        }

        //TODO: XML комментарии
        private void OnCircuitChanged(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        


    }
}
