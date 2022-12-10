using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class DobavljaciRepository : Repository<Dobavljac>
    {
        public DobavljaciRepository() : base(new STONKS_DB())
        {
        }

        public IQueryable<Dobavljac> GetByOIB(string oib,string name)
        {
            var query = from e in Entities
                        where e.OIB == oib || e.naziv == name
                        select e;
            return query;
        }
        public override int Update(Dobavljac entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
