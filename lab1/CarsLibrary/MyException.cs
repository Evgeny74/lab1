using System;

namespace CarsLibrary
{
    /// <summary>
    /// Пользовательское исключение
    /// </summary>
    public class MyException : Exception
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public MyException() : base() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        public MyException(String message) : base(message) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        /// <param name="inner">Ошибка</param>
        public MyException(String message, Exception inner) : base(message,inner) { }
    }

    public class NotEnoughFuelException : MyException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public NotEnoughFuelException() : base() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        public NotEnoughFuelException(String message) : base(message) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        /// <param name="inner">Ошибка</param>
        public NotEnoughFuelException(String message, Exception inner) : base(message,inner) { }
    }

    public class StringFormatException : MyException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public StringFormatException() : base() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        public StringFormatException(String message) : base(message) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        /// <param name="inner">Ошибка</param>
        public StringFormatException(String message, Exception inner) : base(message,inner) { }
    }

    public class WrongLength : MyException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public WrongLength() : base() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        public WrongLength(String message) : base(message) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        /// <param name="inner">Ошибка</param>
        public WrongLength(String message, Exception inner) : base(message, inner) { }
    }

    public class NegativeValueException : MyException
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public NegativeValueException() : base() { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        public NegativeValueException(String message) : base(message) { }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="message">Передаваемое сообщение</param>
        /// <param name="inner">Ошибка</param>
        public NegativeValueException(String message, Exception inner) : base(message, inner) { }
    }


}
