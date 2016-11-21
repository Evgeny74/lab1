using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace lab1.Serialization
{
    
    /// <summary>
    /// Класс для сериализации коллекции в XML, и дисериализации
    /// </summary>
    /// <typeparam name="T">Тип элементов коллекции</typeparam>
    public class XMLSerializer<T> : ISerializer<T>
    {
        private bool validated = true;
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
            //serializer.
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
            XmlSchemaInference infer = new XmlSchemaInference();
            XmlSchemaSet schemaSet =
              infer.InferSchema(new XmlTextReader(output));

            XmlWriter w = XmlWriter.Create("someXSD.xsd");
            foreach (XmlSchema schema in schemaSet.Schemas())
            {
                schema.Write(w);
            }
            w.Close();
        }
        /// <summary>
        /// Метод десериализации из XML
        /// </summary>
        /// <param name="input">Путь к файлу</param>
        /// <returns>Получившаяся после десериализации коллекция</returns>
        public MyCollection<T> deSerialize(String input)
        {
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            schemaSet.Add(null, "someXSD.xsd");
            XDocument xDoc = XDocument.Load(input);
            try
            {
                xDoc.Validate(schemaSet, ValidationCallBack);
                StreamReader streamReader = new StreamReader(input);
                MyCollection<T> col = (MyCollection<T>)serializer.Deserialize(streamReader);
                if (validated)
                    return col;
            }
            catch(XmlSchemaValidationException ex){}
            validated = true;
            return new MyCollection<T>();
        }

        private void ValidationCallBack(object sender, ValidationEventArgs args)
        {
            if (args.Severity == XmlSeverityType.Warning)
                Console.WriteLine("\tWarning: Matching schema not found.  No validation occurred." + args.Message);
            else
                Console.WriteLine("\tValidation error: " + args.Message);
            validated = false;

        }
    }
}
