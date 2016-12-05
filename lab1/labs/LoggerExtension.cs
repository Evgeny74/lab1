using System;
using CarsLibrary;

namespace labs
{
    public static class LoggerExtension
    {
        public static void Log(this Logger logger,string message)
        {
            logger.getOutput().WriteLine($"{DateTime.Now}: {message}");
        }
    }
}
