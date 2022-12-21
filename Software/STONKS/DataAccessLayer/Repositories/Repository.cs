using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        public virtual int AddNew(T entity, bool save = true)
        {
            Entities.Add(entity);
            Context.SaveChanges();
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

        public int SaveChanges()
        {
            int affectedRows = 0;
            try
            {
                affectedRows = Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
            }
            return affectedRows;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
