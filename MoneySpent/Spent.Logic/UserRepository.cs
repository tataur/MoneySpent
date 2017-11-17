using Spent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spent.Logic
{
    public class UserRepository : ISpentRepository<UserEntity>
    {
        List<UserEntity> userEntityQueryable = new List<UserEntity>();

        public void AddItem(UserEntity item)
        {
            userEntityQueryable.Add(item);
        }

        public void DeleteItem(Guid id)
        {
            var item = userEntityQueryable.FirstOrDefault(i => i.userId == id);
            userEntityQueryable.Remove(item);
        }

        public List<UserEntity> GetAll()
        {
            return userEntityQueryable;
        }

        public void SubmitChanges()
        {
            throw new NotImplementedException();
        }

        public UserEntity UpdateItem(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
