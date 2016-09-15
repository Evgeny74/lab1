using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using lab1;
using System.Collections;

namespace lab1
{

    /// <summary>
    /// Интерфейс автомобиля
    /// </summary>
    public interface ICar
    {
        
        /// <summary>
        /// Поле имя автомобиля
        /// </summary>
        String Name 
           
        {
            get;
        }
        /// <summary>
        /// Поле, показывающее, двигается автомобиль или нет. True, если автомобиль движется, иначе false
        /// </summary>
        bool Moving 
        {
            set;
            get;
        }
        /// <summary>
        /// Поле, показывающее тип используемого бензина
        /// </summary>
        ushort TypeOfFuel
        {
            get;
        }
        /// <summary>
        /// Поле арзмера топливного бака
        /// </summary>
        uint SizeOfFuelTank 
        { get;}
        /// <summary>
        /// Поле топлива автомобиля
        /// </summary>
        Fuel FuelOfThisCar { get; set; }
        /// <summary>
        /// Метод движения автомобиля
        /// </summary>
        void move();
        /// <summary>
        /// Метод остановки автомобиля
        /// </summary>
        void stop();
        /// <summary>
        /// Метод обгона автомобилем другого автомобиля
        /// </summary>
        /// <param name="auto">Другой, обгоняемый автомобиль</param>
        void overtake(ICar auto); 
        /// <summary>
        /// Метод открытия дверей
        /// </summary>
        void OpenDoors();
        /// <summary>
        /// Метод заправки автомобиля
        /// </summary>
        void refuel();
    }
    /// <summary>
    /// Абстрактный класс автомобиль 
    /// </summary>
    abstract class Automobile : ICar
    {
        /// <summary>
        /// Поле, показывающее, двигается автомобиль или нет. True, если автомобиль движется, иначе false
        /// </summary>
        private bool moving;
        /// <summary>
        /// Поле, показывающее, двигается автомобиль или нет. True, если автомобиль движется, иначе false
        /// </summary>
        public bool Moving
        {
            
            get { return moving; }
            set { moving = value; }
        }
        /// <summary>
        /// Топливо автомобиля
        /// </summary>
        private Fuel fuelOfThisCar;
        /// <summary>
        /// Топливо автомобиля
        /// </summary>
        public Fuel FuelOfThisCar
        {
            get { return fuelOfThisCar; }
            set { fuelOfThisCar = value; }
        }
        /// <summary>
        /// Поле, показывающее тип используемого бензина
        /// </summary>
        private ushort typeOfFuel;
        /// <summary>
        /// Поле, показывающее тип используемого бензина
        /// </summary>
        public ushort TypeOfFuel
        { get { return typeOfFuel; } }
        /// <summary>
        /// Поле имени автомобиля
        /// </summary>
        private string nameOfCar;
        /// <summary>
        /// Поле имени автомобиля
        /// </summary>
        public string Name
        {
            
            get
            {
                return nameOfCar;
            }
        }
        /// <summary>
        /// Размер топливного бака
        /// </summary>
        protected uint sizeOfFuelTank;
        /// <summary>
        /// Размер топливного бака
        /// </summary>
        public uint SizeOfFuelTank
        {
            get { return sizeOfFuelTank; }
        }
        /// <summary>
        /// Конструктор класса Automobile. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Automobile(ushort sizeOfFuelTank,string  carsName)
        {
            moving = false;
            
            this.sizeOfFuelTank = sizeOfFuelTank;
            nameOfCar = carsName;
        }
        /// <summary>
        /// Метод движения автомобиля
        /// </summary>
        public void move()
        {
            Console.WriteLine("I am moving!");
            fuelOfThisCar.FuelLeft = fuelOfThisCar.FuelLeft - 5;

        }
        /// <summary>
        /// Метод остановки автомобиля
        /// </summary>
        public void stop()
        {
            if (moving)
            {
                Console.WriteLine("I stopped.");
                moving = false;
            }
        }
        /// <summary>
        /// Метод обгона другого автомобиля. На вход подается параметр auto
        /// </summary>
        /// <param name="auto">Второй, обгоняемый автомобиль</param>
        public void overtake(ICar auto)
        {
            Console.WriteLine("I overtook " + auto.Name);
        }
        /// <summary>
        /// Метод открытия дверей
        /// </summary>
        public void OpenDoors()
        {
            Console.WriteLine("I opened my doors!");
        }
        /// <summary>
        /// Метод заправки автомобилей
        /// </summary>
        public void refuel()
        {
            stop();
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
    }
    /// <summary>
    /// Класс легокового автомобиля
    /// </summary>
    class Car : Automobile
    {
        /// <summary>
        /// /Конструктор легокового автомобиля. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Car(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Метод открытия багажника
        /// </summary>
        void OpenBoot()
        {
            //Метод открытия багажника
            Console.WriteLine("My boot is open.");
        }
    }
    /// <summary>
    /// Класс внедорожника
    /// </summary>
    class OffRoader : Car
    {
        /// <summary>
        /// /Конструктор внедорожника. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public OffRoader(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        { }
        /// <summary>
        /// Метод движения внедорожника
        /// </summary>
        public void move()
        {
            Console.WriteLine("I am going off road");
            base.move();
            FuelOfThisCar.FuelLeft -= 5;
        }
    }
    /// <summary>
    /// Класс спортивной машины
    /// </summary>
    class SportsCar : Car
    {
        /// <summary>
        /// /Конструктор спортивного автомобиля. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public SportsCar(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank,  carsName)
        { }
        /// <summary>
        /// Метод движения внедорожника
        /// </summary>
        public void move()
        {
            Console.WriteLine("I am going fast");
            FuelOfThisCar.FuelLeft -= 5;
        }
    }
    /// <summary>
    /// Класс грузовика
    /// </summary>
    class Truck : Automobile
    {
        /// <summary>
        /// /Конструктор грузовика. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Truck(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_95(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Метод загрузки грузовика
        /// </summary>
        public void beLoaded()
        {
            
            Console.WriteLine("I am loaded.");
        }
        /// <summary>
        /// Метод разгрузки грузовика
        /// </summary>
        public void unload()
        {
            
            Console.WriteLine("I am unloaded.");
        }
    }
    /// <summary>
    /// Интерфейс тягача
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface ILorry<in T> where T : Trailer
    {
        /// <summary>
        /// Прикрепить прицеп
        /// </summary>
        /// <param name="trailer"></param>
        void AttachATrailer(T trailer);
    }
    /// <summary>
    /// Класс тягача (фуры) 
    /// </summary>
    class Lorry<T> : Automobile,ILorry<T> where T : Trailer
    {
        /// <summary>
        /// /Конструктор тягача. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Lorry(ushort sizeOfFuelTank, string carsName) : base(sizeOfFuelTank, carsName)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Метод прикрепления прицепа. На вход подается параметр trailer
        /// </summary>
        /// <param name="trailer">Прикрепляемый прицеп</param>
        public void AttachATrailer(T trailer)
        {
            //Метод прицепления прицепа
            trailer.beAttached();
            Console.WriteLine("I have a trailer attached");
        }

    }
    /// <summary>
    /// Интерфейсзаправочной станции
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IFillingStation<out T> where T : Automobile
    {
        /// <summary>
        /// Заправить машину
        /// </summary>
        /// <param name="car"></param>
        void fillTheCar(ICar car);
        /// <summary>
        /// Одолжить машину
        /// </summary>
        /// <returns></returns>
        T RemoveCar();
    }
    /// <summary>
    /// Класс заправочной станции
    /// </summary>
    class FillingStation : IFillingStation<Car>
    {
        /// <summary>
        /// 98-ой бензин
        /// </summary>
        private Petrol_98 p98;
        /// <summary>
        /// 95-ый бензин
        /// </summary>
        private Petrol_95 p95;
        /// <summary>
        /// Конструктор заправочной станции. На вход подаются параметры petrol95 и petrol98
        /// </summary>
        /// <param name="petrol95">Количество 95-ого бензина</param>
        /// <param name="petrol98">Количество 98-ого бензина</param>
        public FillingStation(uint petrol95, uint petrol98)
        {
            p95 = new Petrol_95(petrol95);
            p98 = new Petrol_98(petrol98);
        }
        /// <summary>
        /// Методзаправки автомобиля. На вход подается параметр car
        /// </summary>
        /// <param name="car">Автомобиль, который нужно заправить</param>
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
        /// <summary>
        /// Одолжить машину
        /// </summary>
        /// <returns></returns>
        public Car RemoveCar()
        {
            return new Car(50,"Hired car");
        }
    }
    /// <summary>
    /// Интерфейс трейлера
    /// </summary>
    public interface ITrailer
    {
        /// <summary>
        /// Поле, принимающее значение True, если прицеплен, иначе false
        /// </summary>
        bool IsAttached
        {
            set;
            get;
        }
        /// <summary>
        /// Метод прицепления прицепа к фуре 
        /// </summary>
        void beAttached();
    }
    /// <summary>
    /// Класс трейлера
    /// </summary>
    class Trailer : ITrailer
    {
        /// <summary>
        /// Поле, принимающее значение True, если прицеплен, иначе false
        /// </summary>
        private bool isAttached;
        /// <summary>
        /// Поле, принимающее значение True, если прицеплен, иначе false
        /// </summary>
        public bool IsAttached
        {
            get { return isAttached; }
            set { isAttached = value; }
        }
        /// <summary>
        /// Конструктор класса прицеп
        /// </summary>
        public Trailer() { isAttached = false; }
        /// <summary>
        /// Метод прицепления прицепа к фуре 
        /// </summary>
        public void beAttached()
        {
            isAttached = true;
            Console.WriteLine("I am attached to a lorry");
        }
    }
    /// <summary>
    /// Класс большого трейлера
    /// </summary>
    class BigTrailer : Trailer
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BigTrailer() : base() { }
    }
    /// <summary>
    /// Интерфейс топлива
    /// </summary>
    public interface Fuel
    {
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        ushort Type 
        {
            get;
        }
        /// <summary>
        /// Количество оставшегося топлива
        /// </summary>
        uint FuelLeft 
        {
            get;
            set;
        }
    }
    /// <summary>
    /// Класс бензина 95
    /// </summary>
    class Petrol_95 : Fuel
    {
        /// <summary>
        /// Количество оставшегося топлива
        /// </summary>
        private uint fuelLeft;
        /// <summary>
        /// Количество оставшегося топлива
        /// </summary>
        public uint FuelLeft
        {
            set { fuelLeft = value; }
            get { return fuelLeft; }
        }
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        private const ushort _Type = 95;
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        public ushort Type
        {
            get { return _Type; }
        }
        /// <summary>
        /// Конструктор класса 98-ой бензин
        /// </summary>
        /// <param name="amount">Количество бензина</param>
        public Petrol_95(uint amount)
        {
            fuelLeft = amount;
        }
    }
    /// <summary>
    /// Класс бензина 98
    /// </summary>
    class Petrol_98 : Fuel
    {
        /// <summary>
        /// Количество оставшегося топлива
        /// </summary>
        private uint fuelLeft;
        /// <summary>
        /// Количество оставшегося топлива
        /// </summary>
        public uint FuelLeft
        {
            set { fuelLeft = value; }
            get { return fuelLeft; }
        }
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        private const ushort _Type = 98;
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        public ushort Type
        {
            get { return _Type; }
        }
        /// <summary>
        /// Конструктор класса 98-ой бензин
        /// </summary>
        /// <param name="amount">Количество бензина</param>
        public Petrol_98(uint amount)
        {
            fuelLeft = amount;
        }
    }

    //
    class Program
    {
        static void Main(string[] args)
        {
            SportsCar car = new SportsCar(50,"FastCar");
            Car slowCar = new Car(50,"SlowCar");
            MyCollection<Car> x = new MyCollection<Car>();
            x.Add(car);
            x.Add(slowCar);
            MyCollection<Car> y = (MyCollection<Car>) x.Clone();
            //x.Remove(slowCar);
            //Console.WriteLine(x[1].Name);
            //foreach (Car i in y)
            //{
            //    Console.WriteLine(i);
            // }
            //Console.WriteLine(y[1].Name);
            IFillingStation < Car > Fill = new FillingStation(200,200);
            Fill.fillTheCar(car);
            
            ILorry<Trailer> lorry = new Lorry<Trailer>(50, "Name");
            ILorry<BigTrailer> ffkfk = lorry;
            
            Console.Read();
        }
    }

}
