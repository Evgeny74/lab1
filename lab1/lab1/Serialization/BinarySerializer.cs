using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace lab1.Serialization
{
    /// <summary>
    /// Класс для сериализации коллекции в бинарный формат, и дисериализации
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    class BinarySerializer<T> : ISerializer<T>
    {
        /// <summary>
        /// Поле, выполняющее сериализацию
        /// </summary>
        private BinaryFormatter serializer;
        /// <summary>
        /// Конструктор
        /// </summary>
        public BinarySerializer()
        {
            serializer = new BinaryFormatter();
        }
        /// <summary>
        /// Метод сериализации в бинарный формат
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="output">Путь, куда надо сериализовывать</param>
        public void serialize(MyCollection<T> collection, String output)
        {
            var stream = new FileStream(output,FileMode.Create);
            serializer.Serialize(stream,collection);
            stream.Close();
        }
        /// <summary>
        /// Метод десериализации из бинароного формата
        /// </summary>
        /// <param name="input">Путь к файлу</param>
        /// <returns>Получившаяся после десериализации коллекция</returns>
        public MyCollection<T> deSerialize(String input)
        {
            var stream = new FileStream(input, FileMode.Open);
            MyCollection<T> col = (MyCollection<T>)serializer.Deserialize(stream);
            return col;
        }
    }
}
