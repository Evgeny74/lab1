using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Helper
    {
        public static void WriteLog(Object obj,LogArgs args)
        {
            String msg = "";
            switch (args.info)
            {
                case "OnMove":
                    var car = (Automobile) obj;
                    msg = "Moving. Amount of fuel: " + car.FuelOfThisCar.FuelLeft;
                    break;
                case "OnStop":
                    msg = "Stopped";
                    break;
                case "OnOvertake":
                    msg = "Overtook";
                    break;
                case "OnOpenDoors":
                    msg = "Opened doors";
                    break;
                case "OnRefuel":
                    var auto = (Automobile) obj;
                    msg = "Refuelled. Amount of fuel: " + auto.FuelOfThisCar.FuelLeft;
                    break;
                case "OnOpenBoot":
                    msg = "Opened boot";
                    break;
                case "OnBeLoaded":
                    msg = "Was loaded";
                    break;
                case "OnUnload":
                    msg = "Was unloaded";
                    break;
                case "OnAttachTrailer":
                    msg = "Trailer" + "was attached";
                    break;
                case "OnFillTheCar":
                    var fill = (FillingStation) obj;
                    msg = "The car was filled.";
                    break;
                case "OnRemoveTheCar":
                    msg = "Removed the car.";
                    break;
                case "OnBeAttached":
                    msg = "Attached.";
                    break;

            }
            args.output.WriteLine($"\"{args.name}\",{DateTime.Now}: {msg}");
            args.output.Flush();
        }
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

        public static void sort(MyCollection<Car> collection, bool ascend)
        {
            int count = collection.Count;
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
            }
        }
    }

    
}
