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

        public List<Artikl> GetArtikli()
        {
            using (var repo = new ArtikliRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public List<VrstaArtikla> GetVrsteArtikla()
        {
            using (var repo = new VrsteArtiklaRepository())
            {
                List<VrstaArtikla> vrsteArtikla = repo.GetAll().ToList();
                return vrsteArtikla;
            }
        }

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
    }
}
