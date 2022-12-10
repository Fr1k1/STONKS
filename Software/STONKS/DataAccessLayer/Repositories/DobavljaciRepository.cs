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

        public override int Update(Dobavljac entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
