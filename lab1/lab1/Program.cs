using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    

    public interface ICar
    {
        //Интерфейс автомобиля
        String Name //Имя автомобиля
        {
            get;
        }
        bool Moving //True, если автомобиль движется, иначе false
        {
            set;
            get;
        }
        ushort TypeOfFuel // 95-ый иил 98-ой бензин
        {
            get;
        }
        uint SizeOfFuelTank // Размер топливного бака
        { get;}
        Fuel FuelOfThisCar { get; set; } // Само топливо
        void move(); // Метод движения автомобиля
        void stop(); // Метод остановки автомобиля
        void overtake(ICar auto); // Метод обгона другого автомобиля
        void OpenDoors(); // Метод открытия дверей
        void refuel(); // Метод заправки автомобиля
    }

    abstract class Automobile : ICar
    {
        // Абстрактный класс автомобиль
        private bool moving;
        public bool Moving
        {
            get { return moving; }
            set { moving = value; }
        }
        private Fuel fuelOfThisCar;
        public Fuel FuelOfThisCar
        {
            get { return fuelOfThisCar; }
            set { fuelOfThisCar = value; }
        }
        private ushort typeOfFuel;
        public ushort TypeOfFuel
        { get { return typeOfFuel; } }
        private string nameOfCar;
        public string Name
        {
            get
            {
                return nameOfCar;
            }
        }

        protected uint //amountOfFuelLeft,
            sizeOfFuelTank;
        //protected uint AmountOfFuelLeft
       // {
        //    get { return amountOfFuelLeft; }
        //    set { amountOfFuelLeft = value; }
       // }
        public uint SizeOfFuelTank
        {
            get { return sizeOfFuelTank; }
        }
        public Automobile(ushort sizeOfFuelTank,string  carsName)
        {
            moving = false;
            
            this.sizeOfFuelTank = sizeOfFuelTank;
            nameOfCar = carsName;
        }
        public void move()
        {
            Console.WriteLine("I am moving!");
            fuelOfThisCar.FuelLeft = fuelOfThisCar.FuelLeft - 5;

        }
        public void stop()
        {
            if (moving)
            {
                Console.WriteLine("I stopped.");
                moving = false;
            }
        }
        public void overtake(ICar auto)
        {
            Console.WriteLine("I overtook " + auto.Name);
        }
        public void OpenDoors()
        {
            Console.WriteLine("I opened my doors!");
        }
        public void refuel()
        {
            stop();
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
    }

    class Car : Automobile
    {
        // Класс легкового автомобиля
        public Car(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        void OpenBoot()
        {
            //Метод открытия багажника
            Console.WriteLine("My boot is open.");
        }
    }

    class OffRoader : Car
    {
        //Класс внедорожника
        public OffRoader(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        { }
        public void move()
        {
            Console.WriteLine("I am going off road");
            base.move();
            FuelOfThisCar.FuelLeft -= 5;
        }
    }

    class SportsCar : Car
    {
        //Класс спортивного автомобиля
        public SportsCar(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank,  carsName)
        { }
        public void move()
        {
            Console.WriteLine("I am going fast");
        }
    }
    class Truck : Automobile
    {
        //Класс грузовика
        public Truck(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_95(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        public void beLoaded()
        {
            //Метод загрузки грузовика
            Console.WriteLine("I am loaded.");
        }
        public void unload()
        {
            //Метод разгрузки грузовика
            Console.WriteLine("I am unloaded.");
        }
    }

    class Lorry : Automobile
    {
        //Класс тягача (фуры)
        public Lorry(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        public void AttachATrailer(ITrailer trailer)
        {
            //Метод прицепления прицепа
            trailer.beAttached();
            Console.WriteLine("I have a trailer attached");
        }

    }


    class FillingStation 
    {
        //Класс заправочной станции
        private Petrol_98 p98;//98-ой бензин
        private Petrol_95 p95;//95-ый бензин
        public FillingStation(uint petrol95, uint petrol98)
        {
            p95 = new Petrol_95(petrol95);
            p98 = new Petrol_98(petrol98);
        }
        public void fillTheCar(ICar car)
        {
            //Метод для заправки автомобиля
            uint amount = car.SizeOfFuelTank - car.FuelOfThisCar.FuelLeft;
            if (car.TypeOfFuel == 95)
            {
                p95.FuelLeft -= amount;
                car.refuel();
            }
            if (car.TypeOfFuel == 98)
            {
                p98.FuelLeft -= amount;
                car.refuel();
            }
            Console.WriteLine("I filled the " + car.Name);
        }
    }
    public interface ITrailer
    {
        //Интерфейс трейлера
        bool IsAttached //True, если прицеплен, иначе false
        {
            set;
            get;
        }
        void beAttached(); // Метод прицепления прицепа к фуре
    }

    class Trailer : ITrailer
    {
        //Класс трейлера
        private bool isAttached;
        public bool IsAttached
        {
            get { return isAttached; }
            set { isAttached = value; }
        }
        public Trailer() { isAttached = false; }
        public void beAttached()
        {
            isAttached = true;
            Console.WriteLine("I am attached to a lorry");
        }
    }

    public interface Fuel
    {
        //Интерфейс топлива
        ushort Type //Тип топлива (95-ый или 98-ой)
        {
            get;
        }
        uint FuelLeft //Количество оставшегося топлива
        {
            get;
            set;
        }
    }

    class Petrol_95 : Fuel
    {
        private uint fuelLeft;
        public uint FuelLeft
        {
            set { fuelLeft = value; }
            get { return fuelLeft; }
        }
        private const ushort _Type = 95;
        public ushort Type
        {
            get { return _Type; }
        }
        public Petrol_95(uint amount)
        {
            fuelLeft = amount;
        }
    }

    class Petrol_98 : Fuel
    {
        private uint fuelLeft;
        public uint FuelLeft
        {
            set { fuelLeft = value; }
            get { return fuelLeft; }
        }
        private const ushort _Type = 98;
        public ushort Type
        {
            get { return _Type; }
        }
        public Petrol_98(uint amount)
        {
            fuelLeft = amount;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar car = new SportsCar(50,"FastCar");
            car.move();
            Car slowCar = new Car(50,"SlowCar");
            slowCar.move();
            car.overtake(slowCar);
            FillingStation fill = new FillingStation(50000,50000);
            fill.fillTheCar(car);
            Console.Read();
        }
    }

}
