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
    }
}
