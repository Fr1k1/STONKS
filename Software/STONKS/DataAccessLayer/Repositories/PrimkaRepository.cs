using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataAccessLayer.Repositories
{
    public class PrimkaRepository : Repository<Primka>
    {
        //Author : Filip Milohanović
        public PrimkaRepository() : base(new STONKS_DB())
        {
        }

        public override IQueryable<Primka> GetAll()
        {
            var query = from e in Entities.Include("Dobavljaci")
                        select e;
            return query;
        }

        
        public override int Add(Primka entity, bool save = true)
        {
            Entities.Attach(entity);
            var record = Entities.Add(entity);
            if (save)
            {
                if (SaveChanges() > 0)      // if record added succesfully then return its auto generated id, else return 0 which means that there were no affeted rows
                    return record.id;   
                else
                    return 0;
            }
            else
                return 0;
        }
        public override int Update(Primka entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
