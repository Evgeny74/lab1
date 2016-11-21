using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace lab1
{
    /// <summary>
    /// Реализация коллекции на основе класса List
    /// </summary>
    /// <typeparam name="T">Тип параметра</typeparam>
    [Serializable]
    public class MyCollection<T> : ICollection<T>, ICloneable, IEnumerator<T>
    {
        /// <summary>
        /// Основной список коллекции
        /// </summary>
        
        private List<T> list;
        /// <summary>
        /// Количество элементов в коллекции
        /// </summary>
        public int Count
        {
            get { return list.Count; }
        }
        /// <summary>
        /// Позиция
        /// </summary>
        private int position = -1;
        /// <summary>
        /// Поле, показывающее, является ли список "Только для чтения" или нет
        /// </summary>
        private bool _IsReadOnly;
        /// <summary>
        /// Геттер поля _IsReadOnly;
        /// </summary>
        public bool IsReadOnly
        {
            get { return _IsReadOnly; }
        }
        /// <summary>
        /// Геттеры и сеттеры для обращения к коллекции с помощью квадратных скобок
        /// </summary>
        /// <param name="index">Тип хранящихся данных</param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return list[index]; }
            set { list.RemoveAt(index); list.Insert(index, value); }
        }
        /// <summary>
        /// Делегат функции сортировки
        /// </summary>
        public sorting S;
        /// <summary>
        /// Конструктор коллекции
        /// </summary>
        /// <param name="s">Метод сортировки коллекции</param>
        public MyCollection(sorting s)
        {
            S = s;
            list = new List<T>();
        }
        /// <summary>
        /// Конструктор из List
        /// </summary>
        /// <param name="list"></param>
        public MyCollection(List<T> list)
        {
            this.list = list;
        }
        /// <summary>
        /// Конструктор коллекции
        /// </summary>
        public MyCollection()
        {
            list = new List<T>();
        }
        /// <summary>
        /// Метод добавления элемента в коллекцию
        /// </summary>
        /// <param name="Item"></param>
        public void Add(T Item)
        {
            list.Add(Item);
        }
        /// <summary>
        /// Метод очищения коллекции
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }
        /// <summary>
        /// Метод удаления элемента из коллекции
        /// </summary>
        /// <param name="Item">Элемент, который нужно удалить</param>
        /// <returns>Возвращает результат удаления: удачно или нет</returns>
        public bool Remove(T Item)
        {
            return list.Remove(Item);
        }
        /// <summary>
        /// Проверка на то, содержит ли коллекция определенное значение или нет
        /// </summary>
        /// <param name="Item">Проверяемое значение</param>
        /// <returns>Возвращает результат проверки: удачно или нет</returns>
        public bool Contains(T Item)
        {
           return  list.Contains(Item);
        }
        /// <summary>
        /// Копирование коллекции в массив
        /// </summary>
        /// <param name="Item">Массив, в который копируется коллекция</param>
        /// <param name="Count">Индекс, с которого начинается копирование</param>
        public void CopyTo(T[] Item,int Index)
        {
            list.CopyTo(Item,Index);
        }
        /// <summary>
        /// Возвращает енумератор
        /// </summary>
        /// <returns>Са енумератор</returns>
       // public IEnumerator<T> GetEnumerator()
      //  {
       //     return list.GetEnumerator();
       // }
        /// <summary>
        /// Возвращает енумератор
        /// </summary>
        /// <returns>Сам енумератор</returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        /// <summary>
        /// Клонирование коллекции
        /// </summary>
        /// <returns>Клон коллекции</returns>
        public object Clone()
        {
            MyCollection<T> newCol = new MyCollection<T>(S);
            for (int i = 0; i < list.Count; i++)
                newCol.list.Add(list[i]);
            return newCol;
        }
        /// <summary>
        /// Текущий элемент
        /// </summary>
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        /// <summary>
        /// Текущий элемент
        /// </summary>
        public T Current
        {
            get
            {
                try
                {
                    return list[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
        /// <summary>
        /// Перейти к следующему элементу
        /// </summary>
        /// <returns>True, если можно перейти к следующему элементу, иначе False</returns>
        public bool MoveNext()
        {
            position++;
            return (position < list.Count);
        }
        /// <summary>
        /// Начать отсчет заново
        /// </summary>
        public void Reset()
        {
            position = -1;
        }
        /// <summary>
        /// Уничтожить элементы
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Делегат для сортировки элементов
        /// </summary>
        /// <param name="comparison">Метод сравнения 2 объектов</param>
        /// 
        public delegate  void  sorting(MyCollection<T> collection, bool ascend, Action<double> progress);
        /// <summary>
        /// Сравнение 2 объектов
        /// </summary>
        /// <param name="res">Делегат: метод сравнения 2 объектов</param>
        /// <param name="x">1-ый объект</param>
        /// <param name="y">2-ой объект</param>
        /// <returns></returns>
        public int Compare(Func<T, T, int> res, T x, T y)
        {
            return res(x,y);
        }
        /// <summary>
        /// Функция сортировки коллекции
        /// </summary>
        public async Task Sort()
        {
            var t = Task.Run(() => S(this, true, Helper.Progress) );
            
        }
        /// <summary>
        /// Метод вывода всей коллекции
        /// </summary>
        /// <param name="disp">Метод вывода отдельного элемента колекции</param>
        public void DisplayCollection(Action<T> disp)
        {
            foreach (T car in list)
                disp(car);
        }
  
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }
    }
}
