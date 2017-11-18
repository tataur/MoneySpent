using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Spent.Logic
{
    public interface ISpentRepository<T>
    {
        IQueryable<T> Queryable();
        T AddItem(T item);
        //T GetItem(Guid id);
        //void UpdateItem(Guid id);
        T DeleteItem(T item);
        void SubmitChanges();
    }
}
