using System.ComponentModel;


namespace Model
{
    /// <summary>
    /// Перечисление
    /// </summary>
    public enum ElementTypes
    {
        //NOTE: В идеале еще описание доавить вот таким аттрибутом к каждому значению. Ну и XML комменты.
        //[Description("")]
        [Description("Закоротка")]
        Wire = 0,
        [Description("Резистор")]
        Resistor,
        [Description("Катушка индуктивности")]
        Inductor,
        [Description("Конденсатор")]
        Capacitor
    }
}