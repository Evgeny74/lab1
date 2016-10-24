using System;
using System.IO;
using System.Threading;

namespace lab1
{
    class ExceptionLogger 
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
        /// Контсруктор
        /// </summary>
        /// <param name="path">Путь к файлу, куда пишутся логи</param>
        private Object mutex;
        public ExceptionLogger(String path)
        {
            mutex = new object();
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
                catch (DirectoryNotFoundException e)
                {
                    Output = Console.Out;
                }
            }
        }
        /// <summary>
        /// Обработка пользовательских исключений
        /// </summary>
        /// <param name="e">Пользовательскоеисключение</param>
        public void HandleCustomException(MyException e)
        {
            new Thread(() =>
            {
               lock (mutex)
               {
                   Output.WriteLine(DateTime.Now + ": Custom exception occured : " + e.Message);
                   Output.Flush();
               }
           })
            { IsBackground = true }.Start();
        }
        /// <summary>
        /// Обработка системных исключений
        /// </summary>
        /// <param name="e">Системное исключение</param>
        public void HandleSystemException(Exception e)
        {
            new Thread(() =>
            {
                lock (mutex)
                {
                    Output.WriteLine(DateTime.Now + ": System exception : " + e.Message);
                    Output.Flush();
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
