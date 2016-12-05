using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xunit;
using CarsLibrary;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирования коллекции
    /// </summary>
    public class CollectionTests
    {
        /// <summary>
        /// Тестирование доступа к элементам по индексу
        /// </summary>
        [Fact]
        public void IndexTest()
        {
            MyCollection<Car> col = new MyCollection<Car>();
            Car car = new Car(50,"v",false,new Fuel(50,98));
            col.Add(new Car(50, "f", false, new Fuel(50, 98)));
            col.Add(new Car(50, "k", false, new Fuel(50, 98)));
            col[1] = car;
            Assert.Equal(car,col[1]);
        }
        /// <summary>
        /// Тестирования метода Clone
        /// </summary>
        [Fact]
        public void CloneTest()
        {
            MyCollection<Car> col = new MyCollection<Car>();
            col.Add(new Car(50, "f", false, new Fuel(50, 98)));
            col.Add(new Car(50, "k", false, new Fuel(50, 98)));
            MyCollection<Car> col1 = (MyCollection<Car>)col.Clone();
            compareCollections(col,col1);
            
        }
        /// <summary>
        /// Метод сравнения двух коллекций
        /// </summary>
        /// <param name="col1">Первая коллекция</param>
        /// <param name="col2">Вторая коллекция</param>
        public void compareCollections(MyCollection<Car> col1, MyCollection<Car> col2)
        {
            Assert.Equal(col1.Count, col2.Count);
            var it = col2.GetEnumerator();
            foreach (var car in col1)
            {
                it.MoveNext();
                SerializationTests.compare(car, it.Current);
            }
            it.Dispose();
        }
        /// <summary>
        /// Другие тесты с коллекцией
        /// </summary>
        [Fact]
        public void OtherTests()
        {
            MyCollection<Car> col = new MyCollection<Car>(new List<Car>());
            Car car = new Car();
            col.Add(car);
            Assert.Equal(col.Count,1);
            col.Remove(car);
            Assert.Equal(col.Count,0);
            col.Add(new Car());
            col.Add(new OffRoader());
            col.Clear();
            col.Reset();
            Assert.Equal(col.Count,0);
            Assert.False(col.Contains(car));
            for (int i = 0; i < 5; i++)
            {
                col.Add(new Car());
            }
            col.DisplayCollection(Car.displaying);
            foreach (var auto in col)
            {
                Assert.NotNull(auto);  
            }
            
        }

    }
}
