using Spent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Spent.Logic
{
    public class CommonRepository<T> : ISpentRepository<T>
    {
        private readonly List<T> _list;
        private readonly List<T> _listNew;

        public CommonRepository(List<T> list)
        {
            _list = list;
            _listNew = new List<T>(list);
        }

        public CommonRepository() : this(new List<T>()) { }

        public T AddItem(T item)
        {
            _listNew.Add(item);
            return item;

        }

        public T DeleteItem(T item)
        {
            _listNew.Remove(item);
            return item;
        }

        public IQueryable<T> Queryable()
        {
            return GetList().AsQueryable();
        }

        public List<T> GetList()
        {
            return _list.ToArray().ToList();
        }

        public void SubmitChanges()
        {
            lock (this)
            {
                _list.Clear();
                _list.AddRange(_listNew);
            }
        }
    }
}
