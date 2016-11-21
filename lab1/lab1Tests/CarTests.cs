using Xunit;
using lab1;

namespace lab1Tests
{
    /// <summary>
    /// Тесты класса  Automobile и его наследников
    /// </summary>
    public class CarTests
    {
        /// <summary>
        /// Тест движения автомобиля
        /// </summary>
        [Fact]
        public void MoveTest()
        {
            SportsCar sCar = new SportsCar();
            Assert.NotNull(sCar);
            Automobile car = new Automobile(50,"",false,new Fuel(50,98));
            uint oldFuel = car.FuelOfThisCar.FuelLeft;
            car.move();
            Assert.Equal(oldFuel - 5, car.FuelOfThisCar.FuelLeft);
            Car car1 = new Car(50, "", false, new Fuel(50, 98));
            oldFuel = car1.FuelOfThisCar.FuelLeft;
            car1.move();
            Assert.Equal(oldFuel - 5, car1.FuelOfThisCar.FuelLeft);
            SportsCar car2 = new SportsCar(50, "", false, new Fuel(50, 98));
            oldFuel = car2.FuelOfThisCar.FuelLeft;
            car2.move();
            Assert.Equal(oldFuel - 5, car2.FuelOfThisCar.FuelLeft);
            OffRoader car3 = new OffRoader(50, "", false, new Fuel(50, 98));
            oldFuel = car3.FuelOfThisCar.FuelLeft;
            car3.move();
            Assert.Equal(oldFuel - 5, car3.FuelOfThisCar.FuelLeft +5);
            Lorry<Trailer >car4 = new Lorry<Trailer>(50, "", false, new Fuel(50, 98));
            oldFuel = car4.FuelOfThisCar.FuelLeft;
            car4.move();
            Assert.Equal(oldFuel - 5, car4.FuelOfThisCar.FuelLeft);
            Truck car5 = new Truck(50, "", false, new Fuel(50, 98));
            oldFuel = car5.FuelOfThisCar.FuelLeft;
            car5.move();
            Assert.Equal(oldFuel - 5, car5.FuelOfThisCar.FuelLeft);
        }
        /// <summary>
        /// Тест запавки автомобиля
        /// </summary>
        [Fact]
        public void FillTheCarTest()
        {
            Automobile car = new Automobile(50, "", false, new Fuel(0, 98));
            uint diff = car.SizeOfFuelTank - car.FuelOfThisCar.FuelLeft;
            uint am = 300;
            FillingStation fill = new FillingStation(400,am);
            fill.fillTheCar(car);
            Assert.Equal(car.SizeOfFuelTank,car.FuelOfThisCar.FuelLeft);
            Assert.Equal(am - diff,fill.getFuel98());
        }
        /// <summary>
        /// Тест различных методов автомобиля
        /// </summary>
        [Fact]
        public void OtherMethodsTests()
        {
            Automobile auto = new Automobile(100,"",false,new Fuel(100,98));
            auto.OpenDoors();
            auto.stop();
            auto.move();
            auto.stop();
            auto.overtake(new Automobile());
            Assert.NotNull(auto);
        }
        /// <summary>
        /// Тесты методов класса Lorry
        /// </summary>
        [Fact]
        public void LorryTests()
        {
            Lorry<Trailer> lorry = new Lorry<Trailer>();
            Assert.NotNull(lorry);
            lorry = new Lorry<Trailer>(100,"",false,new Fuel(100,95));
            Assert.NotNull(lorry);
            lorry.AttachATrailer(new Trailer());
            lorry.OpenDoors();
            lorry.move();
            Assert.Equal(lorry.FuelOfThisCar.FuelLeft,(uint)95);
            lorry.stop();
            lorry.overtake(new Automobile());
            lorry.FuelOfThisCar = new Fuel(97,95);
            Assert.Equal(lorry.FuelOfThisCar.FuelLeft,(uint)97);
            Assert.Equal(lorry.FuelOfThisCar.Type,(uint)95);
            lorry.Moving = true;
            Assert.Equal(lorry.Moving,true);
            lorry.SizeOfFuelTank = 120;
            Assert.Equal(lorry.SizeOfFuelTank,(uint)120);
        }
        /// <summary>
        /// Тесты методов класса Truck
        /// </summary>
        [Fact]
        public void TruckTests()
        {
            
            Truck lorry = new Truck();
            Assert.NotNull(lorry);
            lorry = new Truck(100, "", false, new Fuel(100, 95));
            Assert.NotNull(lorry);
            lorry.OpenDoors();
            lorry.move();
            Assert.Equal(lorry.FuelOfThisCar.FuelLeft, (uint)95);
            lorry.stop();
            lorry.overtake(new Automobile());
            lorry.FuelOfThisCar = new Fuel(97, 95);
            Assert.Equal(lorry.FuelOfThisCar.FuelLeft, (uint)97);
            Assert.Equal(lorry.FuelOfThisCar.Type, (uint)95);
            lorry.Moving = true;
            Assert.Equal(lorry.Moving, true);
            lorry.SizeOfFuelTank = 120;
            Assert.Equal(lorry.SizeOfFuelTank, (uint)120);
            lorry.BeLoaded();
            lorry.Unload();
            Assert.NotNull(lorry);
        }
        /// <summary>
        /// Тест получения автомобиля из конфиг-файла
        /// </summary>
        [Fact]
        public void CarFromConfigTest()
        {
            Car car = Helper.CarFromConfig();
            Assert.NotNull(car);
        }

    }
}
