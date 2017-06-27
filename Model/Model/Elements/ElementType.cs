using System.ComponentModel;

namespace Model.Elements
{
    /// <summary>
    /// Перечисление
    /// </summary>
    public enum ElementTypes
    {
        [Description("Катушка индуктивности")]
        Inductor,
        [Description("Конденсатор")]
        Capacitor,
        [Description("Резистор")]
        Resistor
    }
}