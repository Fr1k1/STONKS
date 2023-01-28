using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class RacuniRepository : Repository<Racun>
    {
        //Author : Ana Škarica 
        public RacuniRepository() : base(new STONKS_DB())
        {

        }

        //Author : Ana Škarica 
        public override IQueryable<Racun> GetAll()
        {
            var query = from e in Entities.Include("Korisnici").Include("NaciniPlacanja").Include("StavkeRacuna")
                        select e;

            return query;
        }

        //Author : Ana Škarica 
        public override IQueryable<Racun> GetByNacinPlacanja(int id)
        {
            var query = from e in Entities.Include("Korisnici").Include("NaciniPlacanja").Include("StavkeRacuna")
                        where e.nacin_placanja_id == id
                        select e;

            return query;
        }

        //Author : Filip Milohanović
        public IQueryable<Racun> GetByDate(DateTime date)
        {
            Console.WriteLine(date.Date.ToString());
            var query = from e in Entities.Include("Korisnici").Include("NaciniPlacanja").Include("StavkeRacuna")
                        where EntityFunctions.TruncateTime(e.vrijeme_izdavanja) == EntityFunctions.TruncateTime(date)
                        select e;

            return query;
        }

        //Author : Ana Škarica 
        public override int AddNew(Racun entity, bool save = true)
        {
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

        //Author : Ana Škarica 
        public override int Add(Racun entity, bool save = true)
        {
            Entities.Attach(entity);
            var record = Entities.Add(entity);
            if (save)
            {
                if (SaveChanges() > 0)
                {
                    return record.id;
                }
                else
                {
                    return 0;
                }
            }
            else return 0;
        }

        //Author : Ana Škarica 
        public override int Update(Racun entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}
