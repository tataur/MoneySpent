using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spent.Logic;
using Spent.Data;

namespace Spent.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserEntity userEntity = new UserEntity { userId = Guid.NewGuid(), userName = "user1" };

            UserRepository repository = new UserRepository();
            repository.AddItem(userEntity);
            var result = repository.GetAll();
            Assert.AreEqual(1, result.Count);
        }
    }
}
