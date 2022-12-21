using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class StavkeServices
    {
        public List<StavkaRacuna> GetStavke(Racun racun)
        {
            using (var repo = new StavkeRepository())
            {
                return repo.GetSelected(racun.id).ToList();
            }
        }

        public bool AddStavke(int artiklId, int racunId, int kolicina)
        {
            bool isSuccessful = false;
            StavkaRacuna stavka = new StavkaRacuna
            {
                artikl_id = artiklId,
                racun_id = racunId,
                kolcina = kolicina
            };

            using (var repo = new StavkeRepository())
            {
                int affectedRows = repo.Add(stavka);
                isSuccessful = affectedRows > 0;
            }

            return isSuccessful;
        }

        
    }
}
