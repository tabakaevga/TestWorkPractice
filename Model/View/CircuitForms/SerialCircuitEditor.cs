using System;
using System.Windows.Forms;
using Model;
using Model.Circuits;
using Model.Elements;

namespace View.CircuitForms
{
    public partial class SerialCircuitEditor : Form
    {
        #region Private variables

        /// <summary>
        /// Список параллельных элементов
        /// </summary>
        private readonly SerialCircuit _circuit;

        #endregion

        #region Constructs

        /// <summary>
        /// Конструктор нового соединения
        /// </summary>
        public SerialCircuitEditor()
        {
            InitializeComponent();
            _circuit = new SerialCircuit();
            _circuit.CircuitChanged += _circuit_OnCircuitChanged;
        }

        /// <summary>
        /// Конструктор редактируемого соединения
        /// </summary>
        /// <param name="circuit"> Редактируемогое соединение </param>
        public SerialCircuitEditor(SerialCircuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            NameTextBox.Text = _circuit.Name;
            RebindList();
            _circuit.CircuitChanged += _circuit_OnCircuitChanged;
        }

        #endregion

        #region Public Properties

        public IComponent CircuitSent { get; private set; }

        #endregion

        #region Private Methods

        /// <summary>
        /// Заполнение листбокса
        /// </summary>
        private void RebindList()
        {
            ComponentsListBox.Items.Clear();
            foreach (var component in _circuit)
                ComponentsListBox.Items.Add(component.Name);
        }

        #endregion

        #region Handlers

        /// <summary>
        /// Обработчик события изменения соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _circuit_OnCircuitChanged(object sender, EventArgs e)
        {
            RebindList();
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку Добавить элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementButton_Click(object sender, EventArgs e)
        {
            var f = new ElementEditor();
            f.ShowDialog();
            if (f.ElementSent != null)
            {
                _circuit.Add(f.ElementSent);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку Добавить соединение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubcircuitButton_Click(object sender, EventArgs e)
        {
            var f = new ParallelCircuitEditor();
            f.ShowDialog();
            if (f.CircuitSent != null)
            {
                _circuit.Add(f.CircuitSent);
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку Удалить элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveComponentButton_Click(object sender, EventArgs e)
        {
            _circuit.RemoveAt(ComponentsListBox.SelectedIndex);
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (_circuit.Any())
            {
                _circuit.Name = NameTextBox.Text;
                CircuitSent = _circuit;
                Close();
            }
            else
            {
                throw new Exception("НЕТ ЭЛЕМЕНТОВ");
            }
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CircuitSent = null;
            Close();
        }

        /// <summary>
        /// Обрабочтик двойного нажатия на компонент в списке
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = ComponentsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (_circuit[index] is IElement)
                {
                    IElement element = _circuit[index] as IElement;
                    var f = new ElementEditor(element);
                    f.ShowDialog();
                    if (f.ElementSent != null)
                    {
                        _circuit[index] = f.ElementSent;
                    }
                }
                if (_circuit[index] is ParallelCircuit)
                {
                    ParallelCircuit circuit = _circuit[index] as ParallelCircuit;
                    var f = new ParallelCircuitEditor(circuit);
                    f.ShowDialog();
                    if (f.CircuitSent != null)
                    {
                        _circuit[index] = f.CircuitSent;
                    }
                }
                RebindList();
            }
        }

        #endregion

        
    }
}