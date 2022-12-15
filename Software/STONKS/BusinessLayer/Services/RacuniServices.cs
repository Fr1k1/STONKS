using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RacuniServices
    {
        public List<Racun> GetRacuni()
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        public List<Racun> GetRacuniFilter(int id)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByNacinPlacanja(id).ToList();
            }
        }

        public int AddRacun(Racun racun)
        {
            int id;
            using (var repo = new RacuniRepository())
            {
                id = repo.AddNew(racun);
            } 
            return id;
        }
    }
}
