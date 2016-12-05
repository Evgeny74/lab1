using CarsLibrary.Serialization;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace CarsLibrary
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
    [Serializable]
    [XmlInclude(typeof(Car))]
    [XmlInclude(typeof(OffRoader))]
    [XmlInclude(typeof(SportsCar))]
    [XmlInclude(typeof(Truck))]
    [XmlInclude(typeof(Lorry<Trailer>))]
    public class Automobile : ICar
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
        /// Поле имени автомобиля
        /// </summary>
        private string nameOfCar;
        /// <summary>
        /// Поле имени автомобиля
        /// </summary>
        public string Name
        {
            set { nameOfCar = value; }
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
            set { sizeOfFuelTank = value; }
            get { return sizeOfFuelTank; }
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
        /// Конструктор по-умолчанию
        /// </summary>
        public Automobile()
        { }
        /// <summary>
        /// Конструктор класса Automobile. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        /// <param name="Moving">Движется или нет</param>
        /// <param name="FuelOfThisCar">Топливо</param>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае неверного (отрицательного размера (или 0) топливного бака)</exception>
        public Automobile(ushort sizeOfFuelTank,string  carsName, bool Moving,Fuel FuelOfThisCar)
        {
            if (sizeOfFuelTank < 1)
                throw new NotEnoughFuelException("Size of fuel tank cant be less than 1.");
            moving = Moving;
            
            this.sizeOfFuelTank = sizeOfFuelTank;
            this.FuelOfThisCar = FuelOfThisCar;
            nameOfCar = carsName;
        }
        /// <summary>
        /// Метод вывода автомобиля на экран
        /// </summary>
        /// <param name="car">Автомобиль</param>
        public static void displaying(ICar car)
        {
            Console.WriteLine(car.Name);
        }
        /// <summary>
        /// Метод сравнения 2 автомобилей по размеру их топливных баков
        /// </summary>
        /// <param name="car1">1-ый автомобиль</param>
        /// <param name="car2">2-ой автомобиль</param>
        /// <returns>Возвращает 1, если 2-ой объект больше первого (т. е. если топливный бак второго автомобиля больше топливного бака первого),
        /// 0, если они равны и -1, если первый больше второго</returns>
        public static int CarsFuelTank(ICar car1, ICar car2)
        {

            return car1.SizeOfFuelTank.CompareTo(car2.SizeOfFuelTank);
        }
        /// <summary>
        /// Событие движения автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnMove = (sender, value) => { };

        /// <summary>
        /// Метод движения автомобиля
        /// </summary>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае недостатка топлива</exception>
        public void move()
        {
            if (fuelOfThisCar.FuelLeft < 5)
                throw new NotEnoughFuelException("Automobile \"" + Name + "\" does not have enough fuel. Remaining fuel: " + fuelOfThisCar.FuelLeft);
            Console.WriteLine("I am moving!");
            fuelOfThisCar.FuelLeft = fuelOfThisCar.FuelLeft - 5;
            OnMove(this, new AutomobileEventArgs() { info = Info.OnMove});
        }
        /// <summary>
        /// Событие остановки автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnStop = (sender, value) => { };
        /// <summary>
        /// Метод остановки автомобиля
        /// </summary>
        public void stop()
        {
            if (moving)
            {
                Console.WriteLine("I stopped.");
                moving = false;
                OnStop(this,new AutomobileEventArgs() { info = Info.OnStop  });
            }
        }
        /// <summary>
        /// Событие обгона другого автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnOvertake = (sender, value) => { };

        /// <summary>
        /// Метод обгона другого автомобиля. На вход подается параметр auto
        /// </summary>
        /// <param name="auto">Второй, обгоняемый автомобиль</param>
        public void overtake(ICar auto)
        {
            Console.WriteLine("I overtook " + auto.Name);
            OnOvertake(this, new AutomobileEventArgs() { info = Info.OnOvertake});
        }
        /// <summary>
        /// Событие открытия дверей
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnOpenDoors = (sender, value) => { };

        /// <summary>
        /// Метод открытия дверей
        /// </summary>
        public void OpenDoors()
        {
            Console.WriteLine("I opened my doors!");
            OnOpenDoors(this, new AutomobileEventArgs() { info = Info.OnOpenDoors });
        }
        /// <summary>
        /// Событие заправки автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnRefuel = (sender, value) => { };

        /// <summary>
        /// Метод заправки автомобилей
        /// </summary>
        public void refuel()
        {
            stop();
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
            OnRefuel(this, new AutomobileEventArgs() { info = Info.OnRefuel });
        }
    }
    /// <summary>
    /// Класс легокового автомобиля
    /// </summary>
    [Serializable]
    public class Car : Automobile
    {
        public Car() : base(){ }
        /// <summary>
        /// /Конструктор легокового автомобиля. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Car(ushort sizeOfFuelTank, string carsName,bool Moving, Fuel FuelOfThisCar) : base(sizeOfFuelTank, carsName,Moving, FuelOfThisCar)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Событие открытия багажника легкового автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnOpenBoot = (sender, value) => { };

        /// <summary>
        /// Метод открытия багажника
        /// </summary>
        public void OpenBoot()
        {
            Console.WriteLine("My boot is open.");
            OnOpenBoot(this, new AutomobileEventArgs() { info = Info.OnOpenBoot });
        }
        
    }
    /// <summary>
    /// Класс внедорожника
    /// </summary>
    [Serializable]
    public class OffRoader : Car
    {
        public OffRoader() { }
        /// <summary>
        /// /Конструктор внедорожника. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public OffRoader(ushort sizeOfFuelTank, string carsName, bool Moving, Fuel FuelOfThisCar) : base(sizeOfFuelTank, carsName,Moving, FuelOfThisCar)
        { }
        //public EventHandler<AutomobileEventArgs> OnMove = (sender, value) => { };
        /// <summary>
        /// Метод движения внедорожника
        /// </summary>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае недостатка топлива</exception>
        public void move()
        {
            if (FuelOfThisCar.FuelLeft < 5)
                throw new NotEnoughFuelException("Automobile \"" + Name + "\" does not have enough fuel. Remaining fuel: " + FuelOfThisCar.FuelLeft);
            Console.WriteLine("I am going off road");
            base.move();
            FuelOfThisCar.FuelLeft -= 5;
            OnMove(this, new AutomobileEventArgs() { info = Info.OnMove });
        }
    }
    /// <summary>
    /// Класс спортивной машины
    /// </summary>
    [Serializable]
    public class SportsCar : Car
    {

        public SportsCar() { }
        /// <summary>
        /// /Конструктор спортивного автомобиля. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public SportsCar(ushort sizeOfFuelTank, string carsName, bool Moving, Fuel FuelOfThisCar) : base(sizeOfFuelTank,  carsName, Moving, FuelOfThisCar)
        { }
        /// <summary>
        /// Метод движения спортивного автомобиля
        /// </summary>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае недостатка топлива</exception>
        public void move()
        {
            if (FuelOfThisCar.FuelLeft < 5)
                throw new NotEnoughFuelException("Automobile \"" + Name + "\" does not have enough fuel. Remaining fuel: " + FuelOfThisCar.FuelLeft);
            Console.WriteLine("I am going fast");
            FuelOfThisCar.FuelLeft -= 5;
            OnMove(this, new AutomobileEventArgs() { info = Info.OnMove }); 
        }
    }
    /// <summary>
    /// Класс грузовика
    /// </summary>
    [Serializable]
    public class Truck : Automobile
    {

        public Truck() { }
        /// <summary>
        /// /Конструктор грузовика. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Truck(ushort sizeOfFuelTank, string carsName, bool Moving, Fuel FuelOfThisCar) : base(sizeOfFuelTank, carsName, Moving, FuelOfThisCar)
        {
            FuelOfThisCar = new Petrol_95(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Событие загрузки грузовика
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnBeLoaded = (sender, value) => { };

        /// <summary>
        /// Метод загрузки грузовика
        /// </summary>
        public void BeLoaded()
        {
            Console.WriteLine("I am loaded.");
            OnBeLoaded(this, new AutomobileEventArgs() { info = Info.OnBeLoaded });
        }
        /// <summary>
        /// Событие разгрузки грузовика
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnUnload = (sender, value) => { };

        /// <summary>
        /// Метод разгрузки грузовика
        /// </summary>
        public void Unload()
        {
            OnUnload(this,new AutomobileEventArgs() { info = Info.OnUnload });
            Console.WriteLine("I am unloaded.");
        }
    }
    /// <summary>
    /// Интерфейс тягача
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILorry<in T> where T : Trailer
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
    [Serializable]
    public class Lorry<T> : Automobile,ILorry<T> where T : Trailer
    {

        public Lorry() { }
        /// <summary>
        /// /Конструктор тягача. Принимает на вход параметры: sizeOfFuelTank и carsName
        /// </summary>
        /// <param name="sizeOfFuelTank">Размер топливного бака</param>
        /// <param name="carsName">Имя или название автомобиля</param>
        public Lorry(ushort sizeOfFuelTank, string carsName, bool Moving, Fuel FuelOfThisCar) : base(sizeOfFuelTank, carsName, Moving, FuelOfThisCar)
        {
            FuelOfThisCar = new Petrol_98(50);
            FuelOfThisCar.FuelLeft = sizeOfFuelTank;
        }
        /// <summary>
        /// Событие прикрепления трейлера
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnAttachTrailer = (sender, value) => { };

        /// <summary>
        /// Метод прикрепления прицепа. На вход подается параметр trailer
        /// </summary>
        /// <param name="trailer">Прикрепляемый прицеп</param>
        public void AttachATrailer(T trailer)
        {
            OnAttachTrailer(this,new AutomobileEventArgs() { info = Info.OnAttachTrailer });
            trailer.BeAttached();
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
    [Serializable]
    public class FillingStation : IFillingStation<Car>
    {
        /// <summary>
        /// Набор автомобилей на заправке
        /// </summary>
        MyCollection<Car> Cars;
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

        public uint getFuel98()
        {
            return p98.FuelLeft;
        }
        /// <summary>
        /// Событие заправки автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnFillTheCar = (sender, value) => { };

        /// <summary>
        /// Метод заправки автомобиля. На вход подается параметр car
        /// </summary>
        /// <param name="car">Автомобиль, который нужно заправить</param>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае неверного значения топлива</exception>
        public void fillTheCar(ICar car)
        {
            OnFillTheCar(this,new AutomobileEventArgs() { info = Info.OnFillTheCar });
            uint amount = car.SizeOfFuelTank - car.FuelOfThisCar.FuelLeft;
            if (car.FuelOfThisCar.Type == 95)
            {
                if (p95.FuelLeft < amount)
                    throw new NegativeValueException("Car \"" + car.Name + "\" cant be filled beacause htere is not enough fuel.");
                p95.FuelLeft -= amount;
                car.refuel();
            }
            if (car.FuelOfThisCar.Type == 98)
            {
                if (p98.FuelLeft < amount)
                    throw new NegativeValueException("Car \"" + car.Name + "\" cant be filled beacause htere is not enough fuel.");
                p98.FuelLeft -= amount;
                car.refuel();
            }
            Console.WriteLine("I filled the " + car.Name);
        }
        /// <summary>
        /// Событие одалживания автомобиля
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        [NonSerialized]
        public EventHandler<AutomobileEventArgs> OnRemoveTheCar = (sender, value) => { };

        /// <summary>
        /// Одолжить машину
        /// </summary>
        /// <returns></returns>
        public Car RemoveCar()
        {
            OnRemoveTheCar(this, new AutomobileEventArgs() { info = Info.OnRemoveTheCar });
            return new Car(50,"Hired car",false,new Petrol_98(50));
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
        void BeAttached();
    }
    /// <summary>
    /// Класс трейлера
    /// </summary>
    [Serializable]
    public class Trailer : ITrailer
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
        /// Событие прикрепления прицепа к фуре
        /// </summary>
        [JsonIgnore]
        [XmlIgnore]
        public EventHandler<AutomobileEventArgs> OnBeAttached = (sender, value) => { };

        /// <summary>
        /// Метод прицепления прицепа к фуре 
        /// </summary>
        public void BeAttached()
        {
            OnBeAttached(this,new AutomobileEventArgs() { info = Info.OnBeAttached});
            isAttached = true;
            Console.WriteLine("I am attached to a lorry");
        }
    }
    /// <summary>
    /// Класс большого трейлера
    /// </summary>
    [Serializable]
    public class BigTrailer : Trailer
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BigTrailer() : base() { }
    }
    /// <summary>
    /// Интерфейс топлива
    /// </summary>
    public interface IFuel
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
    /// Класс топлива
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Petrol_95))]
    [XmlInclude(typeof(Petrol_98))]
    public class Fuel : IFuel
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
        private ushort _Type;
        /// <summary>
        /// //Тип топлива (95-ый или 98-ой)
        /// </summary>
        public ushort Type
        {
            set { _Type = value; }
            get { return _Type; }
        }
        /// <summary>
        /// Конструктор класса топливо
        /// </summary>
        /// <param name="amount">Количество топлива</param>
        /// <param name="Type">Тип топлива</param>
        public Fuel(uint amount,ushort Type)
        {
            fuelLeft = amount;
            this.Type = Type;
        }

        public Fuel()
        { }
    }
    /// <summary>
    /// Класс бензина 95
    /// </summary>
    [Serializable]
    public class Petrol_95 : Fuel
    {
        public Petrol_95() { }
        
        /// <summary>
        /// Конструктор класса 98-ой бензин
        /// </summary>
        /// <param name="amount">Количество бензина</param>
        public Petrol_95(uint amount) : base(amount,95)
        {
        }
    }
    /// <summary>
    /// Класс бензина 98
    /// </summary>
    [Serializable]
    public class Petrol_98 : Fuel
    {
        
        
        /// <summary>
        /// Конструктор класса 98-ой бензин
        /// </summary>
        /// <param name="amount">Количество бензина</param>
        public Petrol_98(uint amount) : base(amount,98)
        {
        }
        public Petrol_98() { }
    }

    //
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

}
