using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
        /*
        public int AddRacun(Racun racun)
        {
            int id;
            using (var repo = new RacuniRepository())
            {
                id = repo.AddNew(racun);
            } 
            return id;
        }*/

        public bool AddRacun(Racun racun, List<StavkaRacuna> stavke)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                List<Artikl> artikli = new List<Artikl>();
                stavke.ForEach(s => artikli.Add(s.Artikli));
                try
                {
                    int racunId = 0; // pocetni id racuna
                    using (var repo = new RacuniRepository())
                    {
                        racunId = repo.Add(racun);
                        Console.WriteLine("ID NOVOG RACUNA = " + racunId); // ovo ionak ne radi kak treba
                    }
                    if(racunId > 0)
                    {
                        // dodaj racun u bazu - prvo u stavke
                        using (var repo = new StavkeRepository())
                        {
                            foreach (var stavka in stavke)
                            {
                                stavka.Artikli = null;
                                stavka.racun_id = racunId;
                                repo.Add(stavka, false);
                            }
                            repo.SaveChanges();
                        }

                        // TODO updateaj stanje skladista

                        transaction.Complete();
                        return true;
                    }
                    return false;
                }
                catch(Exception ex)
                {
                    transaction.Dispose();
                    return false;
                       
                }
            }
        }
    }
}
