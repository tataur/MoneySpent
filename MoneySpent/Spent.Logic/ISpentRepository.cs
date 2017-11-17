using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spent.Logic
{
    public interface ISpentRepository<T>
    {
        List<T> GetAll();
        void AddItem(T item);
        T UpdateItem(Guid id);
        void DeleteItem(Guid id);
        void SubmitChanges();
    }
}
