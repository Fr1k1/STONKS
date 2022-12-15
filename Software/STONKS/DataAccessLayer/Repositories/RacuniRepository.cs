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

        public override IQueryable<Racun> GetByNacinPlacanja(int id)
        {
            var query = from e in Entities.Include("Korisnici").Include("NaciniPlacanja").Include("StavkeRacuna")
                        where e.nacin_placanja_id == id
                        select e;

            return query;
        }

        public override int AddNew(Racun entity, bool save = true)
        {
            //var nacinPlacanja = Context.NaciniPlacanja.SingleOrDefault(v => v.id == entity.nacin_placanja_id);
            //var  = Context.NaciniPlacanja.SingleOrDefault(v => v.id == entity.nacin_placanja_id);

            var racun = new Racun
            {
                nacin_placanja_id = entity.nacin_placanja_id,
                korisnik_id = entity.korisnik_id, 
                vrijeme_izdavanja = entity.vrijeme_izdavanja,
                ukupno = entity.ukupno,
                popust = entity.popust,
                pdv = entity.pdv,
                cjena_bez_pdv = entity.cjena_bez_pdv,
            };
            Entities.Add(racun);
            Context.SaveChanges();           
            return racun.id;
        }

        public override int Update(Racun entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
