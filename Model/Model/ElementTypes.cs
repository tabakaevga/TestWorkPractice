using System.ComponentModel;

namespace Model
{
    //TODO: XML Комментарии
    public enum ElementTypes
    {
        //NOTE: В идеале еще описание доавить вот таким аттрибутом к каждому значению. Ну и XML комменты.
        //[Description("")]
        Wire = 0,
        Resistor,
        Inductor,
        Capacitor
    }
}