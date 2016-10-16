using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    enum Info
        {
        OnMove,
        OnStop,
        OnOvertake,
        OnOpenDoors,
        OnRefuel,
        OnOpenBoot,
        OnBeLoaded,
        OnUnload,
        OnAttachTrailer,
        OnFillTheCar,
        OnRemoveTheCar,
        OnBeAttached

    }
    /// <summary>
    /// Класс логгирования
    /// </summary>
    class Logger
    {
        /// <summary>
        /// Файл, в который выводятся логи
        /// </summary>
        protected String Path;
        /// <summary>
        /// Тип вывода: в консоль или в файл
        /// </summary>
        protected TextWriter Output;
        /// <summary>
        /// Конструктор. На вход подается путь к файлу вывода логов. Если выводить нужно в консоль - нужно подать пустую строку
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public Logger(String path) {
            Path = path;
            if (String.IsNullOrEmpty(path))
            { 
                Output = Console.Out;
            }
            else
            {
                try
                {
                    Output = new StreamWriter(path);
                }
                catch(DirectoryNotFoundException e)
                {
                    Output = Console.Out;
                }
            }
        }
        /// <summary>
        /// Событие, объединяющее все остальные события программы
        /// </summary>
        public EventHandler<LogArgs> OnLog = (sender, value) => { };
        /// <summary>
        /// Подписка на события автомобиля
        /// </summary>
        /// <param name="auto">Сам автомобиль</param>
        public void SubscribeOnEventsAuto(Automobile auto)
        {
            auto.OnMove += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnMove,name = auto.Name,output = Output}); };
            auto.OnStop += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnStop, name = auto.Name, output = Output }); };
            auto.OnOvertake += (sender,e) => { OnLog(sender, new LogArgs() { info = Info.OnOvertake, name = auto.Name, output = Output }); };
            auto.OnOpenDoors += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnOpenDoors, name = auto.Name, output = Output }); };
            auto.OnRefuel += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnRefuel, name = auto.Name, output = Output }); };
        }
        /// <summary>
        /// Подписка на события легкового автомобиля
        /// </summary>
        /// <param name="car">Сам автомобиль</param>
        public void SubscribeOnEventsCar(Car car)
        {
            car.OnOpenBoot += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnOpenBoot, name = car.Name, output = Output }); };
        }
        /// <summary>
        /// Подписка на события фуры
        /// </summary>
        /// <param name="lorry">Сама фура</param>
        public void SubscribeOnEventsLorry(Lorry<Trailer> lorry)
        {
            lorry.OnAttachTrailer += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnAttachTrailer, name = lorry.Name, output = Output }); };
        }
        /// <summary>
        /// Подписка на события грузовика
        /// </summary>
        /// <param name="tr">Сам грузовик</param>
        public void SubscribeOnEventsTruck(Truck tr)
        {
            tr.OnBeLoaded+= (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnBeLoaded, name = tr.Name, output = Output }); };
            tr.OnUnload += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnUnload, name = tr.Name, output = Output }); };
        }
        /// <summary>
        /// Подписка на события заправочной станции
        /// </summary>
        /// <param name="fill">Сама станция</param>
        public void SubscribeOnEventsFillingStation(FillingStation fill)
        {
            fill.OnRemoveTheCar += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnRemoveTheCar, name = "Filling station", output = Output }); };
            fill.OnFillTheCar += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnFillTheCar, name = "Filling station", output = Output }); };
        }
        /// <summary>
        /// Подписка на события трейлера 
        /// </summary>
        /// <param name="tr">Сам трейлер</param>
        public void SubscribeOnEventsTrailer(Trailer tr)
        {
            tr.OnBeAttached += (sender, e) => { OnLog(sender, new LogArgs() { info = Info.OnBeAttached, name = "Trailer", output = Output }); };
        }
    }

}
