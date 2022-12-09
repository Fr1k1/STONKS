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
    }
}
