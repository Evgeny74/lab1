using System;
using CarsLibrary;

namespace labs
{
    /// <summary>
    /// Класс-расширение класса Logger
    /// </summary>
    public static class LoggerExtension
    {
        /// <summary>
        /// Метод логирования методов расширений коллекции
        /// </summary>
        /// <param name="logger">Сам логер</param>
        /// <param name="message">Сообщения для логирования</param>
        public static void Log(this Logger logger,string message)
        {
            logger.getOutput().WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
