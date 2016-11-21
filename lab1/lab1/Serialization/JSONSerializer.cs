using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Collections.Generic;

namespace lab1.Serialization 
{
    /// <summary>
    /// Класс для сериализации коллекции в JSON, и дисериализации
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    public class JSONSerializer<T> : ISerializer<T>
    {
        /// <summary>
        /// Поле, выполняющее сериализацию
        /// </summary>
        private JsonSerializer serializer;
        /// <summary>
        /// Конструктор
        /// </summary>
        public JSONSerializer()
        {
            serializer = new JsonSerializer();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.Formatting = Formatting.Indented;
        }
        /// <summary>
        /// Метод сериализации в JSON
        /// </summary>
        /// <param name="collection">Коллекция</param>
        /// <param name="output">Путь, куда надо сериализовывать</param>
        public void serialize(MyCollection<T> collection,String output)
        {
            using (StreamWriter streamWriter = new StreamWriter(output))
            {
                JsonWriter jsonWriter = new JsonTextWriter(streamWriter);
                serializer.Serialize(jsonWriter, collection);
            }
        }
        /// <summary>
        /// Метод десериализации из JSON
        /// </summary>
        /// <param name="input">Путь к файлу</param>
        /// <returns>Получившаяся после десериализации коллекция</returns>
        public MyCollection<T> deSerialize(String input)
        {
            using ( StreamReader streamReader = new StreamReader(input))
            {
                JsonTextReader jsonReader = new JsonTextReader(streamReader);
                return serializer.Deserialize<MyCollection<T>>(jsonReader);
            }

        }

    }
}
