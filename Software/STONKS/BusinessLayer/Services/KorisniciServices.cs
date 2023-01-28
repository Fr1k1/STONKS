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


        //Author : Martin Friščić (all code)

        public List<Korisnik> GetKorisnici()
        {
            using (var repo = new KorisniciRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public List<string> GetUloga(string username, string password)
        {
            using (var repo = new KorisniciRepository())
            {
                return repo.GetUloga(username, password).ToList(); //gets the role for the user with provided username and password
            }
        }


        public bool GetKorisnik(string username, string password)
        {

            using (var repo = new KorisniciRepository())
            {
                if (repo.Get(username, password).ToList().Count > 0)
                    return true;


                else return false;

            }


        }

        public Korisnik GetLoggedKorisnik(string username, string password)
        {
            using (var repo = new KorisniciRepository())
            {
                return repo.Get(username, password).FirstOrDefault();       //gets the user that is logged in
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

        public string GetPicturePath(string path)
        {
            using (var repo = new KorisniciRepository())
            {
                return repo.GetPath(path);      //returns the path of a picture from database
            }
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
