using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class VrsteArtiklaRepository:Repository<VrstaArtikla>
    {

        public VrsteArtiklaRepository():base (new STONKS_DB()) 
        {

        }

        public override IQueryable<VrstaArtikla> GetAll()
        {
            var query = from e in Entities
                        select e;

            return query;
        }

        public override int Update(VrstaArtikla entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
