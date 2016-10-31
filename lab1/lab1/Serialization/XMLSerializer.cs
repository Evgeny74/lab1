using System;
using System.IO;
using System.Xml.Serialization;

namespace lab1.Serialization
{
    /// <summary>
    /// Класс для сериализации коллекции в XML, и дисериализации
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    class XMLSerializer<T> : ISerializer<T>
    {
        /// <summary>
        /// Поле, выполняющее сериализацию
        /// </summary>
        private XmlSerializer serializer;
        /// <summary>
        /// Конструктор
        /// </summary>
        public XMLSerializer()
        {
            serializer = new XmlSerializer(typeof(MyCollection<T>));
        }
        /// <summary>
        /// Метод сериализации в XML
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="output">Путь, куда надо сериализовывать</param>
        public void serialize(MyCollection<T> collection, String output)
        {
            StreamWriter streamWriter = new StreamWriter(output);
            serializer.Serialize(streamWriter,collection);
            streamWriter.Close();
        }
        /// <summary>
        /// Метод десериализации из XML
        /// </summary>
        /// <param name="input">Путь к файлу</param>
        /// <returns>Получившаяся после десериализации коллекция</returns>
        public MyCollection<T> deSerialize(String input)
        {
            StreamReader streamReader = new StreamReader(input);
            MyCollection<T> col = (MyCollection<T>)serializer.Deserialize(streamReader);
            return col;
        }
    }
}
