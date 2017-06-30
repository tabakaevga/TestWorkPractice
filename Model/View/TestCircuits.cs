#region Using 

using System.Collections.Generic;
using Model;
using Model.Circuits;
using Model.Elements;

#endregion


namespace View
{
    /// <summary>
    /// Класс с тестовыми схемами
    /// </summary>
    public static class TestCircuits
    {
        #region  Public methods 

        /// <summary>
        /// Метод, возвращающий список с тестовыми схемами.
        /// </summary>
        /// <returns></returns>
        public static List<IComponent> TestCircuitsList()
        {
            var testCircuitsList = new List<IComponent>
                { _circuit1(), _circuit2(), _circuit3(), _circuit4(), _circuit5()};
            return testCircuitsList;
        }

        #endregion

        #region - Private methods | Test circuits-

        /// <summary>
        /// Тестовая схема №1.
        /// </summary>
        /// <returns></returns>
        public static IComponent _circuit1()
        {
            var R1 = new Resistor( 100,"R1");
            var C1 = new Capacitor(0.005, "C1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new SerialCircuit();
            circuit1.Name = "circuit11";
            var circuit2 = new ParallelCircuit();
            circuit2.Name = "circuit2";
            circuit2.Add(L1);
            circuit2.Add(C1);
            circuit1.Add(R1);
            circuit1.Add(circuit2);
            return circuit1;
        }

        /// <summary>
        /// Тестовая схема №2.
        /// </summary>
        /// <returns></returns
        public static IComponent _circuit2()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "C1");
            var L1 = new Inductor(0.5, "L1");
            var circuit1 = new SerialCircuit();
            circuit1.Name = "circuit12";
            var circuit2 = new ParallelCircuit();
            circuit2.Name = "circuit2";
            circuit2.Add(R1);
            circuit2.Add(C1);
            circuit1.Add(circuit2);
            circuit1.Add(L1);
            return circuit1;
        }

        /// <summary>
        /// Тестовая схема №3.
        /// </summary>
        /// <returns></returns
        public static IComponent _circuit3()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "C1");
            var L1 = new Inductor(0.5, "L1");
            var L2 = new Inductor(0.5, "L2");
            var L3 = new Inductor(0.5, "L3");
            var circuit1 = new SerialCircuit {Name = "circuit13"};
            var circuit2 = new ParallelCircuit {Name = "circuit2"};
            var circuit3 = new ParallelCircuit {Name = "circuit3"};
            circuit3.Add(L1);
            circuit3.Add(R1);
            circuit2.Add(C1);
            circuit2.Add(L2);
            circuit1.Add(circuit2);
            circuit1.Add(L3);
            circuit1.Add(circuit3);
            return circuit1;
        }

        public static IComponent _circuit4()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "C1");
            var L1 = new Inductor(0.5, "L1");
            var L2 = new Inductor(0.5, "L2");
            var L3 = new Inductor(0.5, "L3");
            var circuit1 = new SerialCircuit { Name = "circuit14" };
            var circuit2 = new ParallelCircuit { Name = "circuit2" };
            var circuit3 = new ParallelCircuit { Name = "circuit3" };
            circuit3.Add(L1);
            circuit3.Add(R1);
            circuit2.Add(C1);
            circuit2.Add(L2);
            circuit2.Add(circuit3);
            circuit1.Add(L3);
            circuit1.Add(circuit3);
            circuit1.Add(circuit2);
            return circuit1;
        }

        public static IComponent _circuit5()
        {
            var R1 = new Resistor(100, "R1");
            var C1 = new Capacitor(0.005, "C1");
            var C2 = new Capacitor(0.005, "C2");
            var C3 = new Capacitor(0.005, "C3");
            var L1 = new Inductor(0.5, "L1");
            var L2 = new Inductor(0.5, "L2");
            var L3 = new Inductor(0.5, "L3");
            var circuit1 = new SerialCircuit { Name = "circuit15" };
            var circuit2 = new ParallelCircuit { Name = "circuit2" };
            var circuit3 = new SerialCircuit() { Name = "circuit3" };
            var circuit4 = new ParallelCircuit { Name = "circuit4" };
            circuit4.Add(L1);
            circuit4.Add(R1);
            circuit3.Add(C1);
            circuit3.Add(R1);
            circuit3.Add(circuit4);
            circuit2.Add(L2);
            circuit2.Add(C2);
            circuit2.Add(C3);
            circuit2.Add(circuit3);
            circuit1.Add(L3);
            circuit1.Add(circuit3);
            circuit1.Add(circuit2);
            
            return circuit1;
        }

        #endregion
    }
}
