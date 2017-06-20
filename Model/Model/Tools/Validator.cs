using System;

namespace Model.Tools
{
    //TODO: Приведи XML комменнтарии к единому виду, у тебя в Elements нет табуляции перед комментом а тут есть
    /// <summary>
    ///     Статический класс, проверяющий корректность ввода входящих величин согласно требованиям к логике программы
    /// </summary>
    public static class Validator
    {
        /// <summary>
        ///     Метод, проверяющий корректность ввода вещественных чисел для сторон фигуры/радиуса окружности
        /// </summary>
        /// <param name="inputValue"> Входящая величина (сторона, радиус) </param>
        public static void ValidateDouble(double inputValue)
        {
            //TODO:Скобочки { }
            if (double.IsNaN(inputValue) || double.IsInfinity(inputValue))
                throw new NotFiniteNumberException($"Input is not a number");
            //TODO:Скобочки { }
            if (inputValue <= 0)
                throw new ArgumentOutOfRangeException($"Input is <0");
        }

        //TODO: XML Комментарии
        public static void ValidateString(string inputString)
        {
            //TODO:Скобочки { }
            if (inputString.Length == 0)
                throw new ArgumentException("String can't be empty.");
        }

        //NOTE: Прочитай про методы расширения, мб эти функции заменишь на метод расширения
        /*
        public static void ValidateDoubleEx(this double inputValue)
        {
            if ( inputValue < 0 )
            {
                throw new ArgumentException("Число меньше нуля");
            }
        } 
        */
        //Использовать так:
        /*
         * double num=0;
         * num = 10;
         * num.ValidateDoubleEx();
         * ConsoleWriteLine("Число больше или равно 0");
         */


    }

}