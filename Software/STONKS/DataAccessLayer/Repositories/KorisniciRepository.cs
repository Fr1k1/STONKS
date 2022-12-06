using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class KorisniciRepository:Repository<Korisnik>
    {

        public KorisniciRepository() : base(new STONKS_DB())
        {

        }

        public override IQueryable<Korisnik> GetAll()
        {
            var query = from e in Entities.Include("Uloga")
                        select e;

            return query;
        }

        public override int Add(Korisnik entity, bool save = true)
        {
            var uloga = Context.Uloge.SingleOrDefault(u => u.id == entity.uloga_id);

            var korisnik = new Korisnik { 
            ime = entity.ime,
            prezime = entity.prezime,
            OIB=entity.OIB,
            korime=entity.korime,
            lozinka=entity.lozinka,
            uloga_id=entity.uloga_id,
            Uloge=uloga,
            };

            Entities.Add(korisnik);

            if (save)
            {
                return SaveChanges();
            }

            else return 0;
        }

        /* public IQueryable<Korisnik> GetKorisnik(Korisnik korisnik)
         {
             var query=from e in Entities.Include("Uloga")
                       where korisnik.
                       select e
         }*/





        /*public override int Add(Artikl entity, bool save = true)
        {
            var vrstaArtikla = Context.VrsteArtikla.SingleOrDefault(v => v.id == entity.vrsta_artikla_id);

            var artikl = new Artikl
            {
                VrsteArtikla = vrstaArtikla,
                naziv = entity.naziv,
                sifra = entity.sifra,
                jed_cijena = entity.jed_cijena,
                pdv = entity.pdv,
                vrsta_artikla_id = entity.vrsta_artikla_id,
                barkod = entity.barkod,

            };

            Entities.Add(artikl);

            if (save)
            {
                return SaveChanges();
            }

            else return 0;

        }*/

        public override int Update(Korisnik entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}

