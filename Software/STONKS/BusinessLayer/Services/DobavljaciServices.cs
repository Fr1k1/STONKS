using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class DobavljaciServices
    {

        public bool AddDobavljac(Dobavljac dobavljac)
        {
            using ( var repo = new DobavljaciRepository())
            {
                if (repo.Add(dobavljac) > 0)
                    return true;
                else
                    return false;
            }

        }

        public bool AlreadyExists(string oib,string name)
        {
            using (var repo = new DobavljaciRepository())
            {
                if (repo.GetByOIB(oib, name).ToList().Count > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
