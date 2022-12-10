using System;
using System.Data.Entity;
using System.Linq;


namespace DataAccessLayer.Repositories
{
    public abstract class Repository<T> : IDisposable where T : class
    {
        protected STONKS_DB Context;

        protected DbSet<T> Entities;

        public Repository(STONKS_DB context)
        {
            Context = context;
            Entities = Context.Set<T>();    
        }

        public virtual IQueryable<T> GetAll()
        {
            var query = from e in Entities
                        select e;
            return query;
        }

        public virtual IQueryable<T> GetSelected(int id)
        {
            var query = from e in Entities
                        select e;
            return query;
        }

        public virtual IQueryable<T> GetByNacinPlacanja(int id)
        {
            var query = from e in Entities
                        select e;
            return query;
        }

        public virtual int Add(T entity, bool save = true)
        {   
            Entities.Attach(entity);
            Entities.Add(entity);
            if (save)
                return SaveChanges();
            else
                return 0;
        }

        public virtual int Remove(T entity, bool save = true)
        {
            Entities.Attach(entity);
            Entities.Remove(entity);
            if (save)
                return SaveChanges();
            else
                return 0;
        }

        public abstract int Update(T entity, bool save = true);

        protected int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
