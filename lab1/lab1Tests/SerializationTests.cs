using System;
using Xunit;
using lab1;
using lab1.Serialization;

namespace lab1Tests
{
    /// <summary>
    /// Класс тестирования сериализации
    /// </summary>
    public class SerializationTests
    {
        /// <summary>
        /// Коллекция для сериализации и десериализации
        /// </summary>
        private MyCollection<Automobile> collection;
        /// <summary>
        /// Конструктор
        /// </summary>
        public SerializationTests()
        {
            collection = new MyCollection<Automobile>();
            collection.Add(new Automobile(200,"car1",false,new Fuel(200,98)));
            collection.Add(new Automobile(250, "car2", true, new Fuel(250, 98)));
            collection.Add(new Automobile(150,"car3",false,new Fuel(150,98)));
        }
        /// <summary>
        /// Тест сериализации в бинарный файл
        /// </summary>
        [Fact]
        public void TestBinary()
        {
            BinarySerializer<Automobile> binarySerializer = new BinarySerializer<Automobile>();
            binarySerializer.serialize(collection,"binary.txt");
            var newColection = binarySerializer.deSerialize("binary.txt");
            compareCollections(newColection);
        }
        /// <summary>
        /// Тест сериализации в XML-файл
        /// </summary>
        [Fact]
        public void TestXML()
        {
            XMLSerializer<Automobile> xmlSerializer = new XMLSerializer<Automobile>();
            xmlSerializer.serialize(collection, "myxml.xml");
            var newColection = xmlSerializer.deSerialize("myxml.xml");
            compareCollections(newColection);
        }
        /// <summary>
        /// Тест сериализации в JSON-файл
        /// </summary>
        [Fact]
        public void TestJSON()
        {
            JSONSerializer<Automobile> jsonSerializer = new JSONSerializer<Automobile>();
            jsonSerializer.serialize(collection, "myjson.json");
            var newColection = jsonSerializer.deSerialize("myjson.json");
            compareCollections(newColection);
        }
        /// <summary>
        /// Метод сравнения коллекций
        /// </summary>
        /// <param name="deserializedCollection">Коллекция для сравнения</param>
        public void compareCollections(MyCollection<Automobile> deserializedCollection)
        {
            Assert.NotNull(deserializedCollection);
//            Assert.Equal(collection.Count,deserializedCollection.Count);
            Console.WriteLine(collection.Count + " " + deserializedCollection.Count);
            var it = deserializedCollection.GetEnumerator();
            foreach (var car in collection)
            {
                it.MoveNext();
                compare(car,it.Current);
            }
            it.Dispose();
        }
        /// <summary>
        /// Сравнение двух автомобилей
        /// </summary>
        /// <param name="auto1">Первый</param>
        /// <param name="auto2">Второй</param>
        public static  void compare(Automobile auto1, Automobile auto2)
        {
            Assert.Equal(auto1.Name,auto2.Name);
            Assert.Equal(auto1.Moving,auto2.Moving);
            Assert.Equal(auto1.SizeOfFuelTank, auto2.SizeOfFuelTank);
            compareFuel(auto1.FuelOfThisCar,auto2.FuelOfThisCar);
        }
        /// <summary>
        /// Сравнения топлива
        /// </summary>
        /// <param name="fuel1">Первое топливо</param>
        /// <param name="fuel2">Второе топливо</param>
        public static void compareFuel(Fuel fuel1, Fuel fuel2)
        {
            Assert.Equal(fuel1.FuelLeft,fuel2.FuelLeft);
            Assert.Equal(fuel1.Type,fuel2.Type);
        }
    }
}
