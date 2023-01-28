using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ArtikliServices
    {

        //Author : Martin Friščić


        public List<Artikl> GetArtikli()
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        //Author : Martin Friščić


        public List<Artikl> GetArtikliAbecedno()
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetAbecedno().ToList();     //calls the method and gets the articles ordered by name
            }
        }

        //Author : Martin Friščić


        public List<Artikl> GetArtikliPoCijeni()
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetPoCijeni().ToList();  //calls the method and gets the articles ordered by price
            }
        }

        //Author : Filip Milohanović


        public Artikl GetArtikl(string sifra)
        {
            using (var repo = new ArtikliRepository())
            {
                var artikli = repo.GetBySifra(sifra).ToList();
                if (artikli.Count > 0)
                    return artikli[0];
                else
                    return null;
            }
        }


        //Author : Ana Škarica

        public Artikl GetArtikl(int id)
        {
            using (var repo = new ArtikliRepository())
            {
                var artikli = repo.GetArtiklById(id).ToList();
                if (artikli.Count > 0)
                    return artikli[0];
                else
                    return null;
            }
        }



        //Author : Martin Friščić


        public List<VrstaArtikla> GetVrsteArtikla()
        {
            using (var repo = new VrsteArtiklaRepository())
            {
                List<VrstaArtikla> vrsteArtikla = repo.GetAll().ToList();
                return vrsteArtikla;
            }
        }

        //Author : Martin Friščić


        public int GetArtikliPoVrsti(string name)
        {
            using (var repo = new ArtikliRepository())
            {
                var artikli = repo.GetByType(name).ToList();
                if (artikli.Count > 0)
                    return artikli.Count;
                else
                    return 0;
            }
        }

        //Author : Martin Friščić


        public bool DodajArtikl(Artikl artikl)
        {
            bool isSuccessful = false;

            using (var repo = new ArtikliRepository())
            {
                int affectedRows = repo.Add(artikl);
                isSuccessful = affectedRows > 0;
            }

            return isSuccessful;
        }

        //Author : Martin Friščić


        public List<Artikl> SearchArtikli(string name)
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetByName(name).ToList();
            }
        }

        //Author : Martin Friščić


        public List<Artikl> FilterByType(string name)
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetByType(name).ToList();
            }
        }

        public void ChangeSaldo(Artikl artikl, int quantity)
        {
            using (var repo = new ArtikliRepository())
            {
                Console.WriteLine("before" + artikl.saldo);
                artikl.saldo += quantity;
                Console.WriteLine("after" + artikl.saldo);
                int affectedRows = repo.Update(artikl);
                Console.WriteLine("affected" + affectedRows);
            }
        }

        //Author : Ana Škarica
        public double GetPDV(int id)
        {
            double pdv = GetArtikl(id).pdv;
            return pdv;
        }
    }
}
