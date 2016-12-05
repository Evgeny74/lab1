using System;
using CarsLibrary;

namespace labs
{
    class Program
    {
        static void Main(string[] args)
        { 
            Logger log = new Logger("");
            MyCollection<Automobile> col = new MyCollection<Automobile>();
            MyCollectionExtension.Logger = log;
            col.Add(new Car(100,"name1",false,new Fuel(100,98)));
            col.Add(new Car(60, "name2", false, new Fuel(60, 98)));
            col.Add(new Car(70, "car1", false, new Fuel(70, 95)));
            col.Add(new Car(80, "car2", false, new Fuel(80, 95)));
            col.Add(new Car(90, "car3", false, new Fuel(90, 98)));
            foreach (var car in col.findByTypeOfFuel(98))
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine("///////");
            foreach (var car in col.FindByMaxFuel(90))
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine("///////");
            foreach (var car in col.FindByMinFuel(70))
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine("///////");
            foreach (var car in col.FindByMinMaxFuel(90,70))
            {
                Console.WriteLine(car.Name);
            }
            Console.WriteLine("///////");
            foreach (var car in col.FindByName("n"))
            {
                Console.WriteLine(car.Name);
            }
            Console.ReadLine();
        }
    }
}
