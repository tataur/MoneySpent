using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spent.Logic;
using Spent.Data;
using System.Linq;

namespace Spent.Test
{
    [TestClass]
    public class UnitTest1
    {
        CommonRepository<UserEntity> repository = new CommonRepository<UserEntity>();
        private void SaveChangesRepo()
        {
            repository.SubmitChanges();
        }

        [TestMethod]
        public void AddItem_Success()
        {
            UserEntity userEntity = new UserEntity { userId = Guid.NewGuid(), userName = "user1" };
            repository.AddItem(userEntity);
            repository.SubmitChanges();

            var result = repository.Queryable();
            Assert.AreEqual(1, result.Count());
        }

        [TestMethod]
        public void DeleteItem_Success()
        {
            UserEntity userEntity = new UserEntity { userId = Guid.NewGuid(), userName = "user1" };
            repository.AddItem(userEntity);
            repository.SubmitChanges();

            repository.DeleteItem(userEntity);
            repository.SubmitChanges();

            var result = repository.Queryable();
            Assert.AreEqual(0, result.Count());
        }
    }
}
