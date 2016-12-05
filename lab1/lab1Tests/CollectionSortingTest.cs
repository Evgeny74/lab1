using Xunit;
using CarsLibrary;
using System;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирования сортировки
    /// </summary>
    public class CollectionSortingTest
    {
        /// <summary>
        /// Тест сортировки
        /// </summary>
        [Fact]
        public void SortingTest()
        {
            MyCollection<Car> col = new MyCollection<Car>();
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                col.Add(new Car((ushort)(rand.Next(50000) + 1), "Car" + i, false, new Fuel(0, 98)));
            }
            Helper.sort(col,true,Helper.Progress);
            for (int i = 1; i < col.Count; i++)
            {
                Assert.True(col[i].SizeOfFuelTank >= col[i-1].SizeOfFuelTank);
            }
        }
    }
}
