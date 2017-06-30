using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View.DrawRelated
{
    /// <summary>
    ///     Форма отрисовки цепи
    /// </summary>
    public partial class GraphicCircuitViewForm : Form
    {
        #region Constructs

        /// <summary>
        ///     Конструктор для отрисовки цепи
        /// </summary>
        /// <param name="circuit">Отрисовываемая цепь</param>
        public GraphicCircuitViewForm(IComponent circuit)
        {
            InitializeComponent();
            Image circitImage = circuit.GetImage();
            picture.Width = circitImage.Width;
            picture.Height = circitImage.Height;
            picture.Image = circitImage;
        }

        #endregion
    }
}