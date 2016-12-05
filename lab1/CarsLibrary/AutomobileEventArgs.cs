using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsLibrary
{
    /// <summary>
    /// Класс аргументов
    /// </summary>
    public class AutomobileEventArgs : EventArgs
    {
        /// <summary>
        /// Информация о типе события
        /// </summary>
        public Info info;
    }
}
