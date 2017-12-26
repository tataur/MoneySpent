using System;
using System.Collections.Generic;

namespace Spent.DAL
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll(); // получение всех объектов
        T Find(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}
