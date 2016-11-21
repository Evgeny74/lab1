using lab1;
using Xunit;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирование геттеров и сеттеров
    /// </summary>
    public class GettersSettersTests
    {
        /// <summary>
        /// Геттеры и сеттеры автомобиля
        /// </summary>
        [Fact]
        public void CarGettersSetters()
        {
            Car car = new Car(50,"some name",false,new Fuel(50,98));
            bool moving = true;
            car.Moving = moving;
            Assert.Equal(car.Moving,moving);
            ushort size = 100;
            car.SizeOfFuelTank = size;
            Assert.Equal(car.SizeOfFuelTank,size);
            string s = "name";
            car.Name = s;
            Assert.Equal(car.Name,s);
            Fuel fuel = new Fuel(100,95);
            car.FuelOfThisCar = fuel;
            Assert.Equal(car.FuelOfThisCar.FuelLeft,fuel.FuelLeft);
            Assert.Equal(car.FuelOfThisCar.Type,fuel.Type);
        }
        /// <summary>
        /// Геттеры и сеттеры заправочной станции
        /// </summary>
        [Fact]
        public void FillingSstationSettersGettersTests()
        {
            FillingStation fill = new FillingStation(1000,1000);
            Assert.Equal(fill.getFuel98(),(uint)1000);
        }
        /// <summary>
        /// Геттеры и сеттеры трейлера
        /// </summary>
        [Fact]
        public void TrailerSettersGettersTest()
        {
            Trailer tr = new Trailer();
            tr.IsAttached = false;
            Assert.False(tr.IsAttached);
        }
    }
}
