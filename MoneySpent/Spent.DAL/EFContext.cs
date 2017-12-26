using System.Data.Entity;

namespace Spent.DAL
{
    class EFContext : DbContext
    {
        public DbSet<MoneyEntity> Money { get; set; }
        public DbSet<TypeEntity> Types { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<EFContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
