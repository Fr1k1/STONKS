using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class NacinPlacanjaRepository : Repository<NacinPlacanja>
    {
        //Author : Ana Škarica (all code)
        public NacinPlacanjaRepository() : base(new STONKS_DB())
        {

        }

        public override IQueryable<NacinPlacanja> GetAll()
        {
            var query = from e in Entities
                        select e;

            return query;
        }

        public override int Update(NacinPlacanja entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
