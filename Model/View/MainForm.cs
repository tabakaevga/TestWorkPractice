using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Model.Circuits;
using Model.Elements;
using View.CircuitForms;
using View.DrawRelated;
using View.Tools;
using IComponent = Model.IComponent;

namespace View
{
    /// <summary>
    ///     Главная форма
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructs

        /// <summary>
        ///     Конструктор главной формы
        /// </summary>
        public MainForm()
        {
            _circuitList = new List<IComponent>();
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Заполнение списка
        /// </summary>
        private void RefillList()
        {
            CircuitsList.Items.Clear();
            foreach (var component in _circuitList)
                CircuitsList.Items.Add(component.Name);
        }

        #endregion

        #region Private members

        /// <summary>
        ///     Список двухполюсников
        /// </summary>
        private List<IComponent> _circuitList;

        ///TODO: комментарии
        private readonly List<double> _frequencies = new List<double>
        {
            50,
            20,
            3000,
            0.1,
            1000000
        };

        #endregion

        #region Handlers

        /// <summary>
        ///     Обработчик кнопки отрисовать схему
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrawButton_Click(object sender, EventArgs e)
        {
            var draw = new DrawCircuit(_circuitList[CircuitsList.SelectedIndex]);
            draw.ShowDialog();
        }


        /// <summary>
        ///     Обработчик события нажатия на кнопку расчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalcButton_Click(object sender, EventArgs e)
        {
            ZGridView.Rows.Clear();
            if (CircuitsList.SelectedIndex >= 0)
                foreach (var frequency in _frequencies)
                {
                    var z = _circuitList[CircuitsList.SelectedIndex].CalculateZ(frequency);

                    ZGridView.Rows.Add(
                        Convert.ToString(Math.Round(z.Real, 4), CultureInfo.CurrentCulture) + " + i"
                        + Convert.ToString(Math.Round(z.Imaginary, 4), CultureInfo.CurrentCulture),
                        Convert.ToString(frequency, CultureInfo.CurrentCulture));
                }
        }

        /// <summary>
        ///     Обработчик события изменения цепи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircuitsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_circuitList[CircuitsList.SelectedIndex] is ICircuit)
            {
                var circuit = _circuitList[CircuitsList.SelectedIndex] as ICircuit;
                circuit.CircuitChanged += CalcButton_Click;
            }
            if (_circuitList[CircuitsList.SelectedIndex] is IElement)
            {
                var circuit = _circuitList[CircuitsList.SelectedIndex] as IElement;
                circuit.ValueChanged += CalcButton_Click;
            }
        }

        /// <summary>
        ///     Обработчик кнопки Открыть
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        /// <summary>
        ///     Обработчик кнопки Сохранить как
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        /// <summary>
        ///     Обработчик диалогового окна сохранения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Serializer.SerializeBinary(saveFileDialog1.FileName, ref _circuitList);
        }

        /// <summary>
        ///     Обработчик диалогового окна открытия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Serializer.DeserializeBinary(openFileDialog1.FileName, ref _circuitList);
        }

        /// <summary>
        ///     Обработчик кнопки Добавить Двухполюсник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCircuit_Click(object sender, EventArgs e)
        {
            var f = new SerialCircuitEditor();
            f.ShowDialog();
            if (f.CircuitSent != null)
                _circuitList.Add(f.CircuitSent);
            RefillList();
        }

        /// <summary>
        ///     Обработчик двойного нажатия кнопки мыши по списку
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CircuitsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = CircuitsList.IndexFromPoint(e.Location);
            if (index != ListBox.NoMatches)
            {
                var f = new SerialCircuitEditor(_circuitList[index] as SerialCircuit);
                f.ShowDialog();
                if (f.CircuitSent != null)
                {
                    _circuitList[index] = f.CircuitSent;
                    RefillList();
                }
            }
        }

        /// <summary>
        ///     Обработчик кнопки Удалить двухполюсник
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveCircuit_Click(object sender, EventArgs e)
        {
            _circuitList.RemoveAt(CircuitsList.SelectedIndex);
            RefillList();
        }

        #endregion
    }
}