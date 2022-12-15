using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class StavkePrimkeRepository : Repository<StavkaPrimke>
    {
        public StavkePrimkeRepository() : base(new STONKS_DB())
        {
        }

        public IQueryable<StavkaPrimke> GetByPrimkaId(int primka_id)
        {
            var query = from e in Entities.Include("Artikli").Include("Primke")
                        where e.primka_id == primka_id
                        select e;
            return query;
        }
        public override int Update(StavkaPrimke entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
