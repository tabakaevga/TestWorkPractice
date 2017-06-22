﻿using System;

namespace Model.Tools
{
    /// <summary>
    /// Статический класс, проверяющий корректность ввода входящих величин согласно требованиям к логике программы
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Метод, проверяющий корректность ввода вещественных чисел для сторон фигуры/радиуса окружности
        /// </summary>
        /// <param name="inputValue"> Входящая величина (сторона, радиус) </param>
        //TODO: Если кидаешь исключения, тогда в param пиши требуемое значение, т.е. радиус должен быть больше нуля итд
        public static void ValidateDouble(double inputValue)
        {
            if (double.IsNaN(inputValue) || double.IsInfinity(inputValue))
            {
                throw new NotFiniteNumberException($"Input is not a number");
            }
            if (inputValue <= 0)
            {
                throw new ArgumentOutOfRangeException($"Input is <=0");
            }
        }

        /// <summary>
        /// Валидатор строк
        /// </summary>
        /// <param name="inputString"> Вводимая строка </param>
        public static void ValidateString(string inputString)
        {
            if (inputString.Length == 0)
            {
                throw new ArgumentException("String can't be empty.");
            }
        }
    }

}