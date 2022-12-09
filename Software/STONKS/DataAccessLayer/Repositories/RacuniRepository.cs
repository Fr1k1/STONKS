using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RacuniRepository : Repository<Racun>
    {
        public RacuniRepository() : base(new STONKS_DB())
        {

        }

        public override IQueryable<Racun> GetAll()
        {
            var query = from e in Entities.Include("Korisnici").Include("NaciniPlacanja").Include("StavkeRacuna")
                        select e;

            return query;
        }

        public override int Update(Racun entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
