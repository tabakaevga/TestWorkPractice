using System;
using System.Globalization;
using System.Windows.Forms;
using Model;
using Model.Elements;

namespace View
{
    /// <summary>
    ///     Контрол элементов
    /// </summary>
    public partial class ElementControl : UserControl
    {
        #region Public properties

        ///TODO: я бы пояснил конкретнее что делет свойство
        /// <summary>
        ///     Свойство Элемент
        /// </summary>
        public IComponent Element
        {
            get
            {
                switch (ElementTypeCombo.SelectedIndex)
                {
                    case 0:
                        return new Inductor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    case 1:
                        return new Capacitor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    case 2:
                        return new Resistor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    default:
                        throw new ArgumentNullException("Not known type");
                }
            }
            set
            {
                if (value is IElement)
                {
                    var element = value as IElement;
                    if (value is Inductor)
                        ElementTypeCombo.SelectedIndex = 0;
                    if (value is Capacitor)
                        ElementTypeCombo.SelectedIndex = 1;
                    if (value is Resistor)
                        ElementTypeCombo.SelectedIndex = 2;
                    ValueTextBox.Text = Convert.ToString(element.Value, CultureInfo.CurrentCulture);
                    NameTextBox.Text = element.Name;
                }
            }
        }

        #endregion

        #region Constructs

        /// <summary>
        ///     Конструктор на добавление
        /// </summary>
        public ElementControl()
        {
            InitializeComponent();
            ElementTypeCombo.SelectedIndex = 0;
        }

        /// <summary>
        ///     Конструктор на изменение
        /// </summary>
        /// <param name="element">Изменяемый элемент</param>
        public ElementControl(IElement element)
        {
            InitializeComponent();
            if (element != null)
                Element = element;
        }

        #endregion
    }
}