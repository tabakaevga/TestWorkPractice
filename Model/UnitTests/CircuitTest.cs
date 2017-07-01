using System;
using Model;
using Model.Elements;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    ///     Класс тестов класса Circuit
    /// </summary>
    [TestFixture]
    internal class CircuitTest
    {
        /// <summary>
        ///     Тестирование свойства Наименования Circuit
        /// </summary>
        /// <param name="circuitIndex"> Индекс типа Circuit </param>
        /// <param name="expectedName"> Ожидаемое имя </param>
        [Test]
        [TestCase(0, "Exp Name", TestName = "Последовательная цепь. Корректное именование")]
        [TestCase(1, "Exp Name", TestName = "Параллельная цепь. Корректное именование")]
        [TestCase(0, "", TestName = "Последовательная цепь. Некорректное именование (пустая строка)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(1, "", TestName = "Параллельная цепь. Некорректное именование (пустая строка)",
            ExpectedException = typeof(ArgumentException))]
        public void Circuit_NameTest(int circuitIndex, string expectedName)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            circuit.Name = expectedName;
            Assert.AreEqual(expectedName, circuit.Name);
        }

        /// <summary>
        ///     Тест метода CalculateZ для компонентов IElement
        /// </summary>
        /// <param name="circuitIndex"> Тестируемое соединение </param>
        /// <param name="frequency"> Частота сигнала </param>
        /// <param name="magnitude"> Модуль сопротивления </param>
        [Test]
        [TestCase(2, 50, 185.6729, TestName = "Посл. цепь. Корректное значение frequency")]
        [TestCase(3, 50, 0.6392, TestName = "Пар. цепь. Корректное значение frequency")]
        [TestCase(2, 0, 1, TestName = "Посл. цепь. Некорректное значение frequency (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, 0, 1, TestName = "Пар. цепь. Некорректное значение frequency (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, -50, 1, TestName = "Посл. цепь. Некорректное значение frequency (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, -50, 1, TestName = "Пар. цепь. Некорректное значение frequency (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(4, 50, 0, TestName = "Посл. цепь. Пустая цепь.")]
        [TestCase(5, 50, 0, TestName = "Пар. цепь. Пустая цепь.")]
        public void Circuit_CalculateZ_Test(int circuitIndex, double frequency, double magnitude)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            Assert.AreEqual(magnitude, Math.Round(circuit.CalculateZ(frequency).Magnitude, 4));
        }

        /// <summary>
        /// Тестирование добавления элемента в список
        /// </summary>
        /// <param name="circuitIndex"> Тестируемое соединение </param>
        /// <param name="addingItemName"> Именование добавляемого элемента </param>
        [Test]
        [TestCase(2, "AddItem", TestName = "Посл. цепь. Корректное добавление")]
        [TestCase(3, "AddItem", TestName = "Пар. цепь. Корректное добавление")]
        [TestCase(2, "W1", TestName = "Посл. цепь. Некорректное добавление (элемент с существующим именем)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Component with this name already exists.")]
        [TestCase(3, "W1", TestName = "Пар. цепь. Некорректное добавление (элемент с существующим именем)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Component with this name already exists.")]
        [TestCase(2, "NullItem", TestName = "Посл. цепь. Некорректное добавление (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't add null components.")]
        [TestCase(3, "NullItem", TestName = "Пар. цепь. Некорректное добавление (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't add null components.")]
        public void Circuit_AddTest(int circuitIndex, string addingItemName)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            var addingElement = new Inductor {Name = addingItemName};
            if (addingItemName == "NullItem")
            {
                addingElement = null;
            }
            circuit.Add(addingElement);
            Assert.AreEqual(addingElement.Name, circuit.LastOrDefault().Name);
        }

        /// <summary>
        /// Тестирование удаления из цепи
        /// </summary>
        /// <param name="circuitIndex"> Тестируемая цепь </param>
        /// <param name="removingItemName"> Удаляемый элемент </param>
        [Test]
        [TestCase(2, "W1", TestName = "Посл. цепь. Корректное удаление")]
        [TestCase(3, "W1", TestName = "Пар. цепь. Корректное удаление")]
        [TestCase(2, "NotInList", TestName = "Посл. цепь. Некорректное удаление (элемент с несуществующим именем)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Component doesn't exist.")]
        [TestCase(3, "NotInList", TestName = "Пар. цепь. Некорректное удаление (элемент с несуществующим именем)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Component doesn't exist.")]
        [TestCase(4, "NullList", TestName = "Посл. цепь. Некорректное удаление (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't remove from empty list.")]
        [TestCase(5, "NullList", TestName = "Пар. цепь. Некорректное удаление (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't remove from empty list.")]
        public void Circuit_RemoveTest(int circuitIndex, string removingItemName)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            var expectedCount = circuit.Count;
            IComponent removingElement = new Inductor();
            foreach (var component in circuit)
            {
                if (component.Name == removingItemName)
                {
                    removingElement = component;
                }
            }
            circuit.Remove(removingElement);
            Assert.AreEqual(expectedCount - 1, circuit.Count);
        }

        /// <summary>
        /// Тестирование удаления из цепи по индексу
        /// </summary>
        /// <param name="circuitIndex"> Тестируемая цепь </param>
        /// <param name="removeIndex"> Индекс удаляемого элемента </param>
        [Test]
        [TestCase(2, 0, TestName = "Посл. цепь. Корректное удаление по индексу")]
        [TestCase(3, 0, TestName = "Пар. цепь. Корректное удаление по индексу")]
        [TestCase(2, -1, TestName = "Посл. цепь. Некорректное удаление (индекс <0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, -1, TestName = "Пар. цепь. Некорректное удаление (индекс <0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, 5, TestName = "Посл. цепь. Некорректное удаление (индекс >Count)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, 5, TestName = "Пар. цепь. Некорректное удаление (индекс >Count)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(4, 2, TestName = "Посл. цепь. Некорректное удаление по индексу (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't remove from empty list.")]
        [TestCase(5, 2, TestName = "Пар. цепь. Некорректное удаление по индексу (null)",
            ExpectedException = typeof(ArgumentException), ExpectedMessage = "Can't remove from empty list.")]
        public void Circuit_RemoveAtTest(int circuitIndex, int removeIndex)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            var expectedCount = circuit.Count;
            circuit.RemoveAt(removeIndex);
            Assert.AreEqual(expectedCount - 1, circuit.Count);
        }

        /// <summary>
        /// Тестирование индексатора
        /// </summary>
        /// <param name="circuitIndex"> Тестируемая цепь </param>
        /// <param name="index"> Индекс элемента </param>
        /// <param name="item"> Устанавливаемый элемент </param>
        [Test]
        [TestCase(2, 1, "SetItem", TestName = "Посл. цепь. Корректное обращение по индексу")]
        [TestCase(3, 1, "SetItem", TestName = "Пар. цепь. Корректное обращение по индексу")]
        [TestCase(2, 1, "NullItem", TestName = "Посл. цепь. Корректное обращение по индексу (null item)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(3, 1, "NullItem", TestName = "Пар. цепь. Корректное обращение по индексу",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(2, -1, "", TestName = "Посл. цепь. Некорректное обращение по индексу (индекс <0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, -1, "", TestName = "Пар. цепь. Некорректное обращение по индексу (индекс <0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, 5, "", TestName = "Посл. цепь. Некорректное обращение по индексу (индекс >Count)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(3, 5, "", TestName = "Пар. цепь. Некорректное обращение по индексу (индекс >Count)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(4, 2, "", TestName = "Посл. цепь. Некорректное обращение по индексу по индексу (null)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(5, 2, "", TestName = "Пар. цепь. Некорректное обращение по индексу по индексу (null)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void Circuit_IndexerTest(int circuitIndex, int index, string item)
        {
            var circuit = TestData.TestCircuitsList()[circuitIndex];
            IComponent element = new Inductor();
            if (item == "NullItem")
            {
                element = null;
            }
            circuit[index] = element;
            Assert.AreEqual(circuit[index].Name, element.Name);
        }


    }
}