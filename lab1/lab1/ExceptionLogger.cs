using System;
using System.IO;
using System.Threading;

namespace lab1
{
    public class ExceptionLogger 
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
        public static Object mutex;
        public ExceptionLogger(String path)
        {
            mutex = new object();
            Path = path;
            
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
                    using (var output = getOutput())
                    {
                        output.WriteLine(DateTime.Now + ": Custom exception occured : " + e.Message);
                    }
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
                    using (var output = getOutput()) { 
                        output.WriteLine(DateTime.Now + ": System exception : " + e.Message);
                    }
                }
            })
            { IsBackground = true }.Start();
        }

        private TextWriter getOutput()
        {
            if (String.IsNullOrEmpty(Path))
            {
                Output = Console.Out;
            }
            else
            {
                try
                {
                    Output = new StreamWriter(Path,true);
                }
                catch (DirectoryNotFoundException e)
                {
                    Output = Console.Out;
                }
            }
            return Output;
        }
    }
}
