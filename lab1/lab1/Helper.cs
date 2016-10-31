using System;
using System.IO;

namespace lab1
{
    class Helper
    {
        /// <summary>
        /// Метод вывода логов
        /// </summary>
        /// <param name="obj">Объект-отправитель</param>
        /// <param name="args">Список аргументов</param>
        public static void WriteLog(Object obj,LogArgs args)
        {
            String msg = "";
            switch (args.info)
            {
                case Info.OnMove:
                    var car = (Automobile) obj;
                    msg = "Moving. Amount of fuel: " + car.FuelOfThisCar.FuelLeft;
                    break;
                case Info.OnStop:
                    msg = "Stopped";
                    break;
                case Info.OnOvertake:
                    msg = "Overtook";
                    break;
                case Info.OnOpenDoors:
                    msg = "Opened doors";
                    break;
                case Info.OnRefuel:
                    var auto = (Automobile) obj;
                    msg = "Refuelled. Amount of fuel: " + auto.FuelOfThisCar.FuelLeft;
                    break;
                case Info.OnOpenBoot:
                    msg = "Opened boot";
                    break;
                case Info.OnBeLoaded:
                    msg = "Was loaded";
                    break;
                case Info.OnUnload:
                    msg = "Was unloaded";
                    break;
                case Info.OnAttachTrailer:
                    msg = "Trailer" + "was attached";
                    break;
                case Info.OnFillTheCar:
                    msg = "The car was filled.";
                    break;
                case Info.OnRemoveTheCar:
                    msg = "Removed the car.";
                    break;
                case Info.OnBeAttached:
                    msg = "Attached.";
                    break;

            }
            args.output.WriteLine($"\"{args.name}\",{DateTime.Now}: {msg}");
            args.output.Flush();
        }
        /// <summary>
        /// Метод сортировки коллекции автомобилей
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="ascend">Порядок(убывание или возрастание): true, если возрастание, иначе false</param>
        public static void sort(MyCollection<Automobile> collection, bool ascend)
        {
            int count = collection.Count;
            for (int i = 1; i < count; i++)
            {
                for (int j = 1; j < count - i + 1; j++)
                {
                    if (ascend)
                        if (collection[j - 1].FuelOfThisCar.FuelLeft > collection[j].FuelOfThisCar.FuelLeft)
                        {
                            Automobile car = collection[j];
                            collection[j] = collection[j - 1];
                            collection[j - 1] = car;

                        }
                        else { }
                    else
                        if (collection[j - 1].FuelOfThisCar.FuelLeft < collection[j].FuelOfThisCar.FuelLeft)
                    {
                        Automobile car = collection[j];
                        collection[j] = collection[j - 1];
                        collection[j - 1] = car;
                    }
                }
            }
        }
        /// <summary>
        /// Метод сортировки коллекции легковых автомобилей
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="ascend">Порядок(убывание или возрастание): true, если возрастание, иначе false</param>
        public static void sort(MyCollection<Car> collection, bool ascend, Action<double> progress)
        {
            Console.WriteLine("hello");
            int count = collection.Count;
            progress(0);
            for (int i = 1; i < count; i++)
            {
                for (int j = 1; j < count - i + 1; j++)
                {
                    if (ascend)
                        if (collection[j - 1].FuelOfThisCar.FuelLeft > collection[j].FuelOfThisCar.FuelLeft)
                        {
                            Car car = collection[j];
                            collection[j] = collection[j - 1];
                            collection[j - 1] = car;

                        }
                        else { }
                    else
                        if (collection[j - 1].FuelOfThisCar.FuelLeft < collection[j].FuelOfThisCar.FuelLeft)
                    {
                        Car car = collection[j];
                        collection[j] = collection[j - 1];
                        collection[j - 1] = car;
                    }
                }
                progress((double) i / count);
            }
            progress(1);
        }

        /// <summary>
        /// Создание легкового автомобиля из файла конфигурации
        /// </summary>
        /// <returns>Созданный легковой автомобиль</returns>
        /// <exception cref="WrongLength">Выбрасывается в случае недостатка параметров</exception>
        /// <exception cref="StringFormatException">Выбрасывается в случае,  если строка неверного формата </exception>
        /// <exception cref="NotEnoughFuelException">Выбрасывается в случае,  если у автомобиля слишком мало топлива</exception>
        public static Car CarFromConfig()
        {
            string line,name;
            ushort fuel;
            // System.IO.StreamReader file = new System.IO.StreamReader(@"c:\универ\c#\lab1\CarConfig.txt");
            var lines = File.ReadAllLines(@"c:\универ\c#\lab1\CarConfig.txt");
            if (lines.Length < 2)
                throw new WrongLength("Not enough parameters to create a new car.");
            line = lines[0];    
            if (line.Length < 6)
                throw new WrongLength("Too short string: " + line);
            try
            {
                name = line.Substring(5, line.Length - 5);
            }
            catch (Exception e)
            { throw new StringFormatException("String exception.", e); }
            line = lines[1];
            if (line.Length < 6)
                throw new WrongLength("Too short string: " + line);
            try
            {
                fuel = Convert.ToUInt16(line.Substring(5, line.Length - 5));
            }
            catch (Exception e)
            { throw new NotEnoughFuelException("Too little fuel!",e); }
            return new lab1.Car(fuel,name,false,new Petrol_98(fuel));
        }

        public static void Progress(double progress)
        {
            Console.WriteLine("Sorting, " + progress * 100 + "% complete.");
        }
    }

    
}
