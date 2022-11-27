using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UlogeRepository : Repository<Uloga>
    {
        public UlogeRepository() : base(new STONKS_DB())
        {
        }

        public override int Update(Uloga entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
