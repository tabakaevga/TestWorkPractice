using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Model.Elements;
using Model.Tools;

namespace Model.Circuits
{
    /// <summary>
    ///     Контур цепи/Соединение
    /// </summary>
    public abstract class Circuit : IComponent
    {
        #region Events

        /// <summary>
        ///     Событие при изменении контура
        /// </summary>
        public virtual event EventHandler CircuitChanged;

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
        ///     Количество элементов
        /// </summary>
        public int Count => Circuits.Count;

        /// <summary>
        ///     Индексатор списка
        /// </summary>
        /// <param name="index"> Индекс </param>
        /// <returns></returns>
        public IComponent this[int index]
        {
            get { return Circuits[index]; }
            set
            {
                if (value == null)
                    throw new ArgumentException("Object is not a component");
                var component = value;
                UnsubscribeFrom(Circuits[index]);
                Circuits[index] = component;
                SubscribeTo(Circuits[index]);
                CircuitChanged?.Invoke(this, new EventArgs());
            }
        }

        #endregion

        #region Private Fields

        /// <summary>
        ///     Список компонентов параллельного соединения
        /// </summary>
        protected readonly List<IComponent> Circuits = new List<IComponent>();

        /// <summary>
        ///     Наименование параллельного соединения
        /// </summary>
        private string _name;

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        ///     Импеданс
        /// </summary>
        /// <param name="frequency"> Частота </param>
        public abstract Complex CalculateZ(double frequency);


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
            Circuits.Add(component);
            OnCircuitChanged(this, new EventArgs());
            SubscribeTo(component);
        }

        /// <summary>
        ///     Удаление компонента
        /// </summary>
        /// <param name="component"> Удаляемый компонент </param>
        public void Remove(IComponent component)
        {
            if (!Circuits.Any())
                throw new ArgumentException("Can't remove from empty list.");
            if (!Circuits.Contains(component))
                throw new ArgumentException("Component doesn't exist.");
            Circuits.Remove(component);
            OnCircuitChanged(this, new EventArgs());
            UnsubscribeFrom(component);
        }


        /// <summary>
        ///     Удаление компонента по индексу
        /// </summary>
        /// <param name="index"></param>
        public void RemoveAt(int index)
        {
            if (!Circuits.Any())
                throw new ArgumentException("Can't remove from empty list.");
            index++;
            Validator.ValidateDouble(index);
            index--;
            var component = Circuits[index];
            Circuits.RemoveAt(index);
            UnsubscribeFrom(component);
            OnCircuitChanged(this, new EventArgs());
        }

        /// <summary>
        ///     Перечисление компонентов
        /// </summary>
        /// <returns></returns>
        public IEnumerator<IComponent> GetEnumerator()
        {
            return Circuits.GetEnumerator();
        }

        /// <summary>
        ///     Первый элемент
        /// </summary>
        /// <returns></returns>
        public IComponent FirstOrDefault()
        {
            return Circuits.FirstOrDefault();
        }

        /// <summary>
        ///     Последний элемент
        /// </summary>
        /// <returns></returns>
        public IComponent LastOrDefault()
        {
            return Circuits.LastOrDefault();
        }

        /// <summary>
        ///     Проверка на наличие объектов
        /// </summary>
        /// <returns></returns>
        public bool Any()
        {
            return Circuits.Any();
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Отписаться от компонента
        /// </summary>
        /// <param name="component">Компонент цепи </param>
        private void UnsubscribeFrom(IComponent component)
        {
            if (component is Circuit)
            {
                var circuit = component as Circuit;
                circuit.CircuitChanged -= CircuitChanged;
            }
            if (component is IElement)
            {
                var element = component as IElement;
                element.ValueChanged -= CircuitChanged;
            }
        }

        /// <summary>
        ///     Поиск элементов
        /// </summary>
        /// <param name="name"> Имя элемента </param>
        /// <returns></returns>
        private IComponent FindComponent(string name)
        {
            foreach (var component in  Circuits)
            {
                if (component.Name == name)
                {
                    return component;
                }
            }
            return null;
        }

        /// <summary>
        ///     Подписаться на компонент
        /// </summary>
        /// <param name="component">Компонент цепи </param>
        private void SubscribeTo(IComponent component)
        {
            if (component is Circuit)
            {
                var circuit = component as Circuit;
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