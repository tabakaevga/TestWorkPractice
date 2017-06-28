using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View.DrawRelated
{
    /// <summary>
    ///     Форма отрисовки цепи
    /// </summary>
    public partial class DrawCircuit : Form
    {
        #region Constructs

        /// <summary>
        ///     Конструктор для отрисовки цепи
        /// </summary>
        /// <param name="circuit">Отрисовываемая цепь</param>
        public DrawCircuit(IComponent circuit)
        {
            InitializeComponent();
            Image image = circuit.GetImage();
            picture.Width = image.Width;
            picture.Height = image.Height;
            picture.Image = image;
        }

        #endregion
    }
}