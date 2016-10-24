﻿using System;
using System.IO;

namespace lab1
{
    class LogArgs : EventArgs
    {
        /// <summary>
        /// Информация о типе события
        /// </summary>
        public Info info;
        /// <summary>
        /// Имя отправителя события
        /// </summary>
        public String name;
        /// <summary>
        /// Куда выводить
        /// </summary>
        public TextWriter output;

    }
}
