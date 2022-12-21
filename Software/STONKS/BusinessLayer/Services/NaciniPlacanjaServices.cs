using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class NaciniPlacanjaServices
    {
        public List<NacinPlacanja> GetNaciniPlacanja()
        {
            using (var repo = new NacinPlacanjaRepository())
            {
                return repo.GetAll().ToList();
            }
        }
    }
}
