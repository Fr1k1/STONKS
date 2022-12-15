using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PrimkaServices
    {   

        public List<Primka> GetPrimke()
        { 
            using (var repo = new PrimkaRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public int GetIdForNewPrimka()
        {
            return GetPrimke().Count + 1;
        }

        public bool AddPrimka(Primka primka,List<StavkaPrimke> stavke)
        {
            var helpList = new List<StavkaPrimke>(stavke);
            using (var repo = new PrimkaRepository())
            {
                
                int success = repo.AddTransactional(primka,stavke);
                var artikliService = new ArtikliServices();
                foreach (var stavka in helpList)
                {
                    artikliService.ChangeSaldo(stavka.Artikli, stavka.kolicina);
                }


                return success > 0;
            }
        }

        

        public List<StavkaPrimke> GetStavkeFromPrimka(Primka primka)
        {
            using (var repo = new StavkePrimkeRepository())
            {
                return repo.GetByPrimkaId(primka.id).ToList();
            }
        }
    }
}
