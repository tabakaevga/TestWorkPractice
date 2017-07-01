using System.Collections.Generic;
using Model.Circuits;
using Model.Elements;

namespace UnitTests
{
    /// <summary>
    ///     Класс данных для тестирования
    /// </summary>
    internal static class TestData
    {
        #region  Public methods 

        /// <summary>
        ///     Метод, возвращающий список с тестовыми схемами.
        /// </summary>
        /// <returns></returns>
        public static List<Circuit> TestCircuitsList()
        {
            var testCircuitsList = new List<Circuit>
                {_circuit1(), _circuit2(), _circuit3(), _circuit4(), _circuit5(), _circuit6(), null};
            return testCircuitsList;
        }

        #endregion

        #region - Private methods | Test circuits-

        /// <summary>
        ///     Тестовая схема №1.
        /// </summary>
        public static Circuit _circuit1()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "W1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new SerialCircuit {Name = "circuit11"};
            var circuit2 = new ParallelCircuit {Name = "circuit2"};
            circuit2.Add(L1);
            circuit2.Add(C1);
            circuit1.Add(R1);
            circuit1.Add(circuit2);
            return circuit1;
        }

        /// <summary>
        ///     Тестовая схема №2.
        /// </summary>
        public static Circuit _circuit2()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "W1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new ParallelCircuit {Name = "circuit12"};
            var circuit2 = new SerialCircuit {Name = "circuit2"};
            circuit2.Add(R1);
            circuit2.Add(C1);
            circuit1.Add(circuit2);
            circuit1.Add(L1);
            return circuit1;
        }

        /// <summary>
        ///     Тестовая схема №3.
        /// </summary>
        public static Circuit _circuit3()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "W1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new SerialCircuit {Name = "circuit13"};
            circuit1.Add(R1);
            circuit1.Add(C1);
            circuit1.Add(L1);
            return circuit1;
        }

        /// <summary>
        ///     Тестовая схема №4.
        /// </summary>
        public static Circuit _circuit4()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "W1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new ParallelCircuit {Name = "circuit14"};
            circuit1.Add(R1);
            circuit1.Add(C1);
            circuit1.Add(L1);
            return circuit1;
        }

        /// <summary>
        ///     Тестовая цепь №5
        /// </summary>
        /// <returns></returns>
        public static Circuit _circuit5()
        {
            var circuit1 = new SerialCircuit {Name = "circuit15"};
            return circuit1;
        }

        /// <summary>
        ///     Тестовая цепь №6
        /// </summary>
        /// <returns></returns>
        public static Circuit _circuit6()
        {
            var circuit1 = new ParallelCircuit {Name = "circuit16"};
            return circuit1;
        }

        #endregion
    }
}