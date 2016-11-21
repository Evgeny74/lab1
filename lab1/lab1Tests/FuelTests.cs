using System;
using lab1;
using Xunit;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирования топлива
    /// </summary>
    public class FuelTests
    {
        /// <summary>
        /// Тестирование конструкторов
        /// </summary>
        [Fact]
        public void ConstructorsTests()
        {
            Petrol_95 petr = new Petrol_95();
            Assert.NotNull(petr);
            Petrol_98 petr98 = new Petrol_98();
            Assert.NotNull(petr98);
        }
    }
}
