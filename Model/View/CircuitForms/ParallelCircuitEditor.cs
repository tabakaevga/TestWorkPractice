using System;
using System.Windows.Forms;
using Model;
using Model.Circuits;

namespace View.CircuitForms
{
    public partial class ParallelCircuitEditor : Form
    {
        #region Private variables

        /// <summary>
        /// Список параллельных элементов
        /// </summary>
        private readonly ParallelCircuit _circuit;

        #endregion

        #region Constructs

        /// <summary>
        /// Конструктор нового соединения
        /// </summary>
        public ParallelCircuitEditor()
        {
            InitializeComponent();
            _circuit = new ParallelCircuit();
            _circuit.CircuitChanged += _circuit_OnCircuitChanged;
        }

        /// <summary>
        /// Конструктор редактируемого соединения
        /// </summary>
        /// <param name="circuit"> Редактируемогое соединение </param>
        public ParallelCircuitEditor(ParallelCircuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
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
            var f = new SerialCircuitEditor();
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

        #endregion








    }
}