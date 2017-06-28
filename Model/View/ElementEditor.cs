using System;
using System.Windows.Forms;
using Model;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Форма редактора элемента
    /// </summary>
    public partial class ElementEditor : Form
    {
        #region Public Properties

        /// <summary>
        ///     Свойство для передачи в родительскую форму
        /// </summary>
        public IComponent ElementSent { get; private set; }

        #endregion

        #region Constructs

        /// <summary>
        ///     Конструктор на добавление элемента
        /// </summary>
        public ElementEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Конструктор на изменение элемента
        /// </summary>
        /// <param name="element">Изменяемый элемент</param>
        public ElementEditor(IComponent element)
        {
            InitializeComponent();
            if (element is IElement)
            {
                var e = element as IElement;
                elementControl1.Element = e;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Обработчик кнопки ОК
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                ElementSent = elementControl1.Element;
                Close();
            }
            catch (Exception)
            {
                throw new NotImplementedException("Скоро допишу");
            }
        }

        /// <summary>
        ///     Обработчик кнопки Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            ElementSent = null;
            Close();
        }

        #endregion
    }
}