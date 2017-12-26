using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spent.Data
{
    public class Context : DbContext
    {
        public Context() : base("MoneySpent")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<EarnCostEntity> earnCostEntity { get; set; }
        public DbSet<UserEntity> userEntity { get; set; }
        public DbSet<TypeEntity> typeEntity { get; set; }
    }
}
