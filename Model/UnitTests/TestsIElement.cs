using System;
using Model.Elements;
using NUnit.Framework;

namespace UnitTests
{
    /// <summary>
    ///     Класс тестов компонентов IElement
    /// </summary>
    [TestFixture]
    internal class TestsIElement
    {
        private bool _eventInvoked;

        private void element_onValueChanged(object sender, EventArgs e)
        {
            _eventInvoked = true;
        }

        /// <summary>
        ///     Тест метода CalculateZ для компонентов IElement
        /// </summary>
        /// <param name="elementIndex"> Индекс тестируемого элемента </param>
        /// <param name="frequency"> Частота сигнала </param>
        [Test]
        [TestCase(0, 50, TestName = "Индуктор. Корректное значение Value")]
        [TestCase(1, 50, TestName = "Конденсатор. Корректное значение Value")]
        [TestCase(2, 50, TestName = "Резистор. Корректное значение Value")]
        [TestCase(0, 0, TestName = "Индуктор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, TestName = "Конденсатор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, TestName = "Резистор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, -50, TestName = "Индуктор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, -50, TestName = "Конденсатор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, -50, TestName = "Резистор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        public void CalculateZ(int elementIndex, double frequency)
        {
            switch (elementIndex)
            {
                case 0:
                {
                    var element = new Inductor();
                    Assert.AreEqual(2 * Math.PI * frequency * element.Value, element.CalculateZ(frequency).Imaginary);
                    break;
                }
                case 1:
                {
                    var element = new Capacitor {Value = 0.001};
                    Assert.AreEqual(-1 / (2 * Math.PI * frequency * element.Value),
                        element.CalculateZ(frequency).Imaginary);
                    break;
                }
                case 2:
                {
                    var element = new Resistor();
                    Assert.AreEqual(element.Value, element.CalculateZ(frequency).Real);
                    break;
                }
            }
        }

        /// <summary>
        ///     Тест конструктора на двух параметрах для компонентов IElement
        /// </summary>
        /// <param name="elementIndex"> Индекс тестируемого компонента </param>
        /// <param name="value"> Значение сопротивления  </param>
        /// <param name="name"> Название компонента </param>
        [Test]
        [TestCase(0, 30, "Sample Text", TestName = "Индуктор. Корректное значение Value и Name")]
        [TestCase(1, 30, "Sample Text", TestName = "Конденсатор. Корректное значение Value и Name")]
        [TestCase(2, 30, "Sample Text", TestName = "Резистор. Корректное значение Value и Name")]
        [TestCase(0, 0, "Sample Text", TestName = "Индуктор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, "Sample Text", TestName = "Конденсатор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, "Sample Text", TestName = "Резистор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, 30, "", TestName = "Индуктор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(1, 30, "", TestName = "Конденсатор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(2, 30, "", TestName = "Резистор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        public void IElement_FullConstructor_Test(int elementIndex, double value, string name)
        {
            switch (elementIndex)
            {
                case 0:
                {
                    var element = new Inductor(value, name);
                    break;
                }
                case 1:
                {
                    var element = new Capacitor(value, name);
                    break;
                }
                case 2:
                {
                    var element = new Resistor(value, name);
                    break;
                }
            }
        }

        /// <summary>
        ///     Тест свойства Name в компонентах IElement
        /// </summary>
        /// <param name="elementIndex"></param>
        /// <param name="name"></param>
        [Test]
        [TestCase(0, "Sample Text", TestName = "Индуктор. Корректное значение Name")]
        [TestCase(1, "Sample Text", TestName = "Конденсатор. Корректное значение Name")]
        [TestCase(2, "Sample Text", TestName = "Резистор. Корректное значение Name")]
        [TestCase(0, "", TestName = "Индуктор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(1, "", TestName = "Конденсатор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        [TestCase(1, "", TestName = "Резистор. Некорректное значение Name (пустое)",
            ExpectedException = typeof(ArgumentException))]
        public void IElement_Name_Test(int elementIndex, string name)
        {
            switch (elementIndex)
            {
                case 0:
                {
                    var element = new Inductor {Name = name};
                    Assert.AreEqual(name, element.Name);
                    break;
                }
                case 1:
                {
                    var element = new Capacitor {Name = name};
                    Assert.AreEqual(name, element.Name);
                    break;
                }
                case 2:
                {
                    var element = new Resistor {Name = name};
                    Assert.AreEqual(name, element.Name);
                    break;
                }
            }
        }

        /// <summary>
        ///     Тест свойства Value компонентов IElement
        /// </summary>
        /// <param name="elementIndex"> Тестируемый компонент </param>
        /// <param name="value"> Значение свойства value </param>
        [Test]
        [TestCase(0, 30, TestName = "Индуктор. Корректное значение Value")]
        [TestCase(1, 30, TestName = "Конденсатор. Корректное значение Value")]
        [TestCase(2, 30, TestName = "Резистор. Корректное значение Value")]
        [TestCase(0, 0, TestName = "Индуктор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, TestName = "Конденсатор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, 0, TestName = "Резистор. Некорректное значение Value (0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, -50, TestName = "Индуктор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(1, -50, TestName = "Конденсатор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(2, -50, TestName = "Резистор. Некорректное значение Value (<0)",
            ExpectedException = typeof(ArgumentOutOfRangeException))]
        [TestCase(0, 1, TestName = "Индуктор. Проверка события ValueChanged",
            ExpectedException = typeof(AssertionException))]
        [TestCase(1, 1, TestName = "Конденсатор. Проверка события ValueChanged",
            ExpectedException = typeof(AssertionException))]
        [TestCase(2, 1, TestName = "Резистор. Проверка события ValueChanged",
            ExpectedException = typeof(AssertionException))]
        public void IElement_Value_Test(int elementIndex, double value)
        {
            switch (elementIndex)
            {
                case 0:
                {
                    var element = new Inductor();
                    element.ValueChanged += element_onValueChanged;
                    element.Value = value;
                    if (_eventInvoked)
                    {
                        _eventInvoked = false;
                        Assert.AreEqual(value, element.Value);
                    }
                    else
                    {
                        Assert.Fail("Wat");
                    }
                    element.ValueChanged -= element_onValueChanged;
                    break;
                }
                case 1:
                {
                    var element = new Capacitor();
                    element.ValueChanged += element_onValueChanged;
                    element.Value = value;
                    if (_eventInvoked)
                    {
                        _eventInvoked = false;
                        Assert.AreEqual(value, element.Value);
                    }
                    else
                    {
                        Assert.Fail("Wat");
                    }
                    element.ValueChanged -= element_onValueChanged;
                    break;
                }
                case 2:
                {
                    var element = new Resistor();
                    element.ValueChanged += element_onValueChanged;
                    element.Value = value;
                    if (_eventInvoked)
                    {
                        _eventInvoked = false;
                        Assert.AreEqual(value, element.Value);
                    }
                    else
                    {
                        Assert.Fail("Wat");
                    }
                    element.ValueChanged -= element_onValueChanged;
                    break;
                }
            }
        }
    }
}