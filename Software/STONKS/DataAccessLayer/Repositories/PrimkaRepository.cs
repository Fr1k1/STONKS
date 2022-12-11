using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class PrimkaRepository : Repository<Primka>
    {
        public PrimkaRepository() : base(new STONKS_DB())
        {
        }

        public override int Update(Primka entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
