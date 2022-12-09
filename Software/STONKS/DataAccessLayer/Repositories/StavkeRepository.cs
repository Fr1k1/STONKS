using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StavkeRepository : Repository<StavkaRacuna>
    {

        public StavkeRepository() : base(new STONKS_DB())
        {

        }

        public override IQueryable<StavkaRacuna> GetSelected(int racunId)
        {
            var query = from e in Entities.Include("Artikli")
                        where e.racun_id == racunId
                        
                        select e;

            return query;
        }

        public override int Update(StavkaRacuna entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
