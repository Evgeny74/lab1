using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ExceptionLogger(String path)
        {

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
            Output.WriteLine(DateTime.Now + ": Custom exception occured : " + e.Message);
            Output.Flush();
        }
        /// <summary>
        /// Обработка системных исключений
        /// </summary>
        /// <param name="e">Системное исключение</param>
        public void HandleSystemException(Exception e)
        {
            Output.WriteLine(DateTime.Now + ": System exception : " + e.Message);
            Output.Flush();
        }
    }
}
