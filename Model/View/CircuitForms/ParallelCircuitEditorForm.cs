#region Using

using System;
using System.Windows.Forms;
using Model;
using Model.Circuits;
using Model.Elements;
using View.ElementRelated;

#endregion

namespace View.CircuitForms
{
    /// <summary>
    ///     Форма параллельного соединения
    /// </summary>
    public partial class ParallelCircuitEditorForm : Form
    {
        #region Private variables

        /// <summary>
        ///     Список параллельных элементов
        /// </summary>
        private readonly ParallelCircuit _circuit;

        #endregion

        #region Public Properties

        public ParallelCircuit CircuitSent { get; private set; }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Заполнение листбокса
        /// </summary>
        private void RebindList()
        {
            ComponentsListBox.Items.Clear();
            foreach (var component in _circuit)
                ComponentsListBox.Items.Add(component.Name);
        }

        #endregion

        #region Constructs

        /// <summary>
        ///     Конструктор нового соединения
        /// </summary>
        public ParallelCircuitEditorForm()
        {
            InitializeComponent();
            _circuit = new ParallelCircuit();
            _circuit.CircuitChanged += _circuit_OnCircuitChanged;
        }

        /// <summary>
        ///     Конструктор редактируемого соединения
        /// </summary>
        /// <param name="circuit"> Редактируемогое соединение </param>
        public ParallelCircuitEditorForm(ParallelCircuit circuit)
        {
            InitializeComponent();
            _circuit = circuit;
            NameTextBox.Text = _circuit.Name;
            RebindList();
            _circuit.CircuitChanged += _circuit_OnCircuitChanged;
        }

        #endregion

        #region Handlers

        /// <summary>
        ///     Обработчик события изменения соединения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _circuit_OnCircuitChanged(object sender, EventArgs e)
        {
            RebindList();
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddElementButton_Click(object sender, EventArgs e)
        {
            var f = new ElementEditorForm();
            f.ShowDialog();
            if (f.ElementSent != null)
                _circuit.Add(f.ElementSent);
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Добавить соединение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSubcircuitButton_Click(object sender, EventArgs e)
        {
            var f = new SerialCircuitEditorForm();
            f.ShowDialog();
            if (f.CircuitSent != null)
                _circuit.Add(f.CircuitSent);
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку Удалить элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveComponentButton_Click(object sender, EventArgs e)
        {
            _circuit.RemoveAt(ComponentsListBox.SelectedIndex);
        }

        /// <summary>
        ///     Обработчик события нажатия на кнопку ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            if (_circuit.Any())
            {
                _circuit.Name = NameTextBox.Text;
                CircuitSent = _circuit;
                _circuit.CircuitChanged -= _circuit_OnCircuitChanged;
                Close();
            }
            else
            {
                throw new Exception("НЕТ ЭЛЕМЕНТОВ");
            }
        }

        /// <summary>
        ///     Обработчик события двойного клика на Списке компонентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComponentsListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            var index = ComponentsListBox.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                if (_circuit[index] is IElement)
                {
                    var element = _circuit[index] as IElement;
                    var f = new ElementEditorForm(element);
                    f.ShowDialog();
                    if (f.ElementSent != null)
                        _circuit[index] = f.ElementSent;
                }
                if (_circuit[index] is SerialCircuit)
                {
                    var circuit = _circuit[index] as SerialCircuit;
                    var f = new SerialCircuitEditorForm(circuit);
                    f.ShowDialog();
                    if (f.CircuitSent != null)
                        _circuit[index] = f.CircuitSent;
                }
                if (_circuit[index] is ParallelCircuit)
                {
                    var circuit = _circuit[index] as ParallelCircuit;
                    var f = new ParallelCircuitEditorForm(circuit);
                    f.ShowDialog();
                    if (f.CircuitSent != null)
                        _circuit[index] = f.CircuitSent;
                }
                RebindList();
            }
        }

        #endregion
    }
}