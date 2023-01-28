using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class KorisniciRepository : Repository<Korisnik>
    {

        public KorisniciRepository() : base(new STONKS_DB())
        {

        }

        //Author : Martin Friščić (all code)


        public override IQueryable<Korisnik> GetAll()
        {
            var query = from e in Entities.Include("Uloge")
                        select e;

            return query;
        }

        public string GetPath(string value)
        {
            using (var context = new STONKS_DB())
            {
                var query = from e in Entities.Include("Uloge")
                            where e.slika.Contains(value)           //gets the picture that contains parameter value
                            select e.slika;
                return query.FirstOrDefault();          //returns the first value in the sequence
            }
        }


        //gets the user for provided username and password
        public IQueryable<Korisnik> Get(string username, string password)
        {
            var query = from e in Entities.Include("Uloge")
                        where e.korime == username && e.lozinka == password 
                        select e;

            return query;
        }


        //gets the role for user with provided username and password
        public IQueryable<string> GetUloga(string username, string password)
        {
            var query = from e in Entities.Include("Uloge")
                        where e.korime == username && e.lozinka == password  
                        select e.Uloge.naziv;

            return query;
        }

        //gets the picture for user with provided username and password

        public IQueryable<string> GetSlika(string username, string password)
        {
            var query = from e in Entities.Include("Uloge")
                        where e.korime == username && e.lozinka == password
                        select e.slika;

            return query;
        }



        public override int Add(Korisnik entity, bool save = true)
        {
            var uloga = Context.Uloge.SingleOrDefault(u => u.id == entity.uloga_id);

            var korisnik = new Korisnik
            {
                ime = entity.ime,
                prezime = entity.prezime,
                OIB = entity.OIB,
                korime = entity.korime,
                lozinka = entity.lozinka,
                uloga_id = entity.uloga_id,
                Uloge = uloga,
                slika = entity.slika,
            };

            Entities.Add(korisnik);

            if (save)
            {
                return SaveChanges();
            }

            else return 0;
        }

        

        public override int Update(Korisnik entity, bool save = true)
        {
            throw new NotImplementedException();
        }
    }
}

