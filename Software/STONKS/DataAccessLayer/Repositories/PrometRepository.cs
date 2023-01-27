using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{   
    public class PrometRepository : Repository<Promet>
    {
        //Author : Filip Milohanović
        public PrometRepository() : base(new STONKS_DB())
        {
        }

        public IQueryable<Promet> GetByDate(DateTime date)
        {
            var query = from e in Entities.Include("Korisnici")
                        where EntityFunctions.TruncateTime(e.datum_vrijeme) == EntityFunctions.TruncateTime(date)
                        select e;
            return query;
        }

        public override int Update(Promet entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
