using System;
using Xunit;
using lab1;
using System.IO;
using System.Threading;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирования логгирования
    /// </summary>
    public class LoggerTests
    {
        /// <summary>
        /// Путть к файлу с логами
        /// </summary>
        private const string file = "c:/универ/logs.txt";
        /// <summary>
        /// Тестирование логгера
        /// </summary>
        [Fact]
        public void LoggerTest() {
            Automobile auto = new Automobile(100,"",false,new Fuel(100,95));
            
            var Logger = new Logger("c:/универ/somelog");
            Logger.SubscribeOnEventsAuto(auto);
            auto.move();
            auto.OpenDoors();
            auto.stop();
            auto.refuel();
            
            Car car = new Car(100,"",false,new Fuel(100,95));
            Logger.SubscribeOnEventsCar(car);
            car.OpenBoot();
            FillingStation fil = new FillingStation(1000,1000);
            Logger.SubscribeOnEventsFillingStation(fil);
            fil.fillTheCar(car);
            fil.RemoveCar();
            Lorry<Trailer> l = new Lorry<Trailer>();

            Logger.SubscribeOnEventsLorry(l);
            l.AttachATrailer(new Trailer());
            Truck tr = new Truck();
            Logger.SubscribeOnEventsTruck(tr);
            tr.BeLoaded();
            tr.Unload();
            Assert.NotNull(Logger);
            car = new Car(50,"s",false,new Fuel(50,98));
            Helper.WriteLog(car, new LogArgs() {info = Info.OnAttachTrailer, output = new StreamWriter("c:/универ/somelogs", true) });
            Helper.WriteLog(car, new LogArgs() {info = Info.OnBeAttached, output = new StreamWriter("c:/универ/somelogs", true) });
            Helper.WriteLog(car, new LogArgs() {info = Info.OnBeLoaded, output = new StreamWriter("c:/универ/somelogs", true) });
            Helper.WriteLog(new FillingStation(1000,1000), new LogArgs() {info = Info.OnFillTheCar, output = new StreamWriter("c:/универ/somelogs", true) });
            Helper.WriteLog(car, new LogArgs() {info = Info.OnMove, output = new StreamWriter("c:/универ/somelogs", true) });
            Thread.Sleep(50);
            Helper.WriteLog(car, new LogArgs() {info = Info.OnOpenBoot, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnOpenDoors, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnOvertake, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnRefuel, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnRemoveTheCar, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnUnload, output = new StreamWriter("c:/универ/somelogs", true) });

            Helper.WriteLog(car, new LogArgs() {info = Info.OnStop, output = new StreamWriter("c:/универ/somelogs", true) });
            
            Helper.Progress(0);
            Assert.True(File.Exists("c:/универ/somelogs"));
        }
        /// <summary>
        /// Тестирование класса ExceptionLogger
        /// </summary>
        [Fact]
        public void ExceptionLoggerTests()
        {
            if (File.Exists(file))
            {
                File.Delete(file);
            }
            ExceptionLogger excLogger = new ExceptionLogger(file);
            excLogger.HandleCustomException(new StringFormatException());
            excLogger.HandleCustomException(new NotEnoughFuelException());
            excLogger.HandleCustomException(new WrongLength());
            excLogger.HandleCustomException(new NegativeValueException());
            excLogger.HandleCustomException(new StringFormatException(""));
            excLogger.HandleCustomException(new NotEnoughFuelException(""));
            excLogger.HandleCustomException(new WrongLength(""));
            excLogger.HandleCustomException(new NegativeValueException(""));
            excLogger.HandleCustomException(new StringFormatException("",new Exception()));
            excLogger.HandleCustomException(new NotEnoughFuelException("", new Exception()));
            excLogger.HandleCustomException(new WrongLength("", new Exception()));
            excLogger.HandleCustomException(new NegativeValueException("", new Exception()));
            Thread.Sleep(100);
            var str = File.ReadAllText(file);
            Assert.True(str.Contains("StringFormatException"));
            Assert.True(str.Contains("NotEnoughFuelException"));
            Assert.True(str.Contains("WrongLength"));
            Assert.True(str.Contains("NegativeValueException"));
        }
    }
}
