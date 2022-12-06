using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class KorisniciServices
    {

        public List<Korisnik> GetKorisnici()
        {
            using (var repo = new KorisniciRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public bool AddKorisnik(Korisnik korisnik)
        {
            bool added = false;

            using (var repo = new KorisniciRepository())
            {
                int affected = repo.Add(korisnik);
                added = affected > 0;
            }

            return added;
        }

        /* public List<Korisnik> GetKorisnik(Korisnik korisnik)
         {
             using (var repo=new KorisniciRepository())
             {
                 var korisnik=repo.
             }
         }*/
    }
}
