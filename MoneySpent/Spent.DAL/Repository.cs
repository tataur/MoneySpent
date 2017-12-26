using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Spent.DAL
{
    public class Repository// : IRepository<MoneyEntity>
    {
        private readonly EFContext context = new EFContext();

        public IEnumerable<TypeEntity> GetTypes()
        {
            return context.Types;
        }

        public IEnumerable<MoneyEntity> GetAll()
        {
            return context.Money;
        }

        public MoneyEntity Find(int id)
        {
            return context.Money.FirstOrDefault(m => m.Id == id);
        }

        public void Create(MoneyEntity entity)
        {
            context.Money.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = Find(id);
            context.Money.Remove(entity);
        }

        public void Update(MoneyEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
