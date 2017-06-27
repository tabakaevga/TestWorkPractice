using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Model.Elements;
using IComponent = Model.IComponent;

namespace View
{
    /// <summary>
    /// Контрол элементов
    /// </summary>
    public partial class ElementControl : UserControl
    {
        #region Constructs

        /// <summary>
        /// Конструктор на добавление
        /// </summary>
        public ElementControl()
        {
            InitializeComponent();
            ElementTypeCombo.SelectedIndex = 0;
        }

        /// <summary>
        /// Конструктор на изменение
        /// </summary>
        /// <param name="element">Изменяемый элемент</param>
        public ElementControl(IElement element)
        {
            InitializeComponent();
            if (element != null)
            {
                Element = element;
                ElementTypeCombo.SelectedIndex = (int)element.Type;
            }
            
        }

        #endregion

        #region Public properties

        /// <summary>
        /// Свойство Элемент
        /// </summary>
        public IComponent Element
        {
            get
            {
                switch (ElementTypeCombo.SelectedIndex)
                {
                    case 0:
                        return (IComponent)new Inductor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    case 1:
                        return (IComponent)new Capacitor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    case 2:
                        return (IComponent)new Resistor(Convert.ToDouble(ValueTextBox.Text), NameTextBox.Text);
                    default:
                        throw new ArgumentNullException("Not known type");
                }
            }
            set
            {

                if (value is IElement)
                {
                    var element = value as IElement;
                    ValueTextBox.Text = Convert.ToString(element.Value, CultureInfo.CurrentCulture);
                    NameTextBox.Text = element.Name;
                }
            }
        }

        #endregion

    }
}
