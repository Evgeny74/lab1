
using System.IO;
using CarsLibrary;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace labs
{
    /// <summary>
    /// Класс расширения коллекции
    /// </summary>
    public static class MyCollectionExtension
    {
        /// <summary>
        /// Логер
        /// </summary>
        public static Logger Logger { get; set; }
        /// <summary>
        /// Поле для сериализации в JSON
        /// </summary>
        private static JsonSerializer JsonSerializer;
        
        static MyCollectionExtension()
        {
            JsonSerializer = new JsonSerializer();
            JsonSerializer.Converters.Add(new JavaScriptDateTimeConverter());
            JsonSerializer.NullValueHandling = NullValueHandling.Ignore;
            JsonSerializer.Formatting = Formatting.Indented;
        }
        /// <summary>
        /// Метод превращения коллекции в строку
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <returns>Строка, в которую была преобразована коллекция</returns>
        public static string ConvertToString<T>(this MyCollection<T> collection) where T : Automobile
        {
            Logger?.Log("Конвертирование коллекции в строку");
            var writer = new StringWriter();
            JsonSerializer.Serialize(writer, collection);
            return writer.ToString();
        }
        /// <summary>
        /// Поиск по имени
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="request">Часть имени или имя целиком</param>
        /// <returns></returns>
        public static MyCollection<T> FindByName<T>(this MyCollection<T> collection, string request)
            where T : Automobile
        {
            Logger?.Log("Поиск по имени");
            MyCollection<T> result = new MyCollection<T>();
            foreach (var autompbile in collection)
            {
                if (autompbile.Name.Contains(request))
                    result.Add(autompbile);
            }

            return result;
        }
        /// <summary>
        /// Поиск по минимальному значения размера бака: найдет все, которые равны или больше
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="min">Параметр поиска</param>
        /// <returns>Все элементы коллекцию, удовлетворяющие параметру</returns>
        public static MyCollection<T> FindByMinFuel<T>(this MyCollection<T> collection, int min) where T : Automobile
        {
            Logger?.Log("Поиск по минимальному размеру топливного бака");
            MyCollection<T> result = new MyCollection<T>();
            foreach (var autompbile in collection)
            {
                if (autompbile.SizeOfFuelTank >= min)
                    result.Add(autompbile);
            }

            return result;
        }
        /// <summary>
        /// Поиск по максимальному значению бака
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="max">Параметр поиска</param>
        /// <returns>Все элементы коллекции, удовлетворяющие параметру поиска</returns>
        public static MyCollection<T> FindByMaxFuel<T>(this MyCollection<T> collection, int max) where T : Automobile
        {
            Logger?.Log("Поиск по максимальному размеру топливного бака");
            MyCollection<T> result = new MyCollection<T>();
            foreach (var autompbile in collection)
            {
                if (autompbile.SizeOfFuelTank <= max)
                    result.Add(autompbile);
            }

            return result;
        }
        /// <summary>
        /// Поиск размеру топливного бака
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекция</param>
        /// <param name="max">Максимальный порог</param>
        /// <param name="min">Минимальный порог</param>
        /// <returns>Все элементы коллекции, удовлетворяющие параметру поиска</returns>
        public static MyCollection<T> FindByMinMaxFuel<T>(this MyCollection<T> collection, int max,int min) where T : Automobile
        {
            Logger?.Log("Поиск по размеру топливного бака");
            MyCollection<T> result = new MyCollection<T>();
            foreach (var autompbile in collection)
            {
                if (autompbile.SizeOfFuelTank <= max && autompbile.SizeOfFuelTank>=min)
                    result.Add(autompbile);
            }

            return result;
        }
        /// <summary>
        /// Поиск по типу топлива
        /// </summary>
        /// <typeparam name="T">Тип членов коллекции</typeparam>
        /// <param name="collection">Коллекции</param>
        /// <param name="type">Тип толива</param>
        /// <returns>Все элементы коллекции, удовлетворяющие параметру поиска</returns>
        public static MyCollection<T> findByTypeOfFuel<T>(this MyCollection<T> collection, int type) where T : Automobile
        {
            Logger?.Log("Поиск по типу топлива");
            MyCollection<T> result = new MyCollection<T>();
            foreach (var autompbile in collection)
            {
                if (autompbile.FuelOfThisCar.Type == type)
                    result.Add(autompbile);
            }

            return result;
        }
    }
}
