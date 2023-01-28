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
        //Author : Ana Škarica 
        public List<Racun> GetRacuni()
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetAll().ToList();
            }
        }

        //Author : Ana Škarica 
        public List<Racun> GetRacuniByDate(DateTime date)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByDate(date).ToList();
            }
        }

        //Author : Ana Škarica 
        public List<Racun> GetRacuniFilter(int id)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByNacinPlacanja(id).ToList();
            }
        }

        //Author : Ana Škarica 
        public int GetRacuniByNacinPlacanja(int id)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByNacinPlacanja(id).ToList().Count();
            }
        }

        //Author : Ana Škarica 
        public bool AddRacun(Racun racun, List<StavkaRacuna> stavke)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = System.Transactions.IsolationLevel.RepeatableRead }))
            {
                List<Artikl> artikli = new List<Artikl>();
                stavke.ForEach(s => artikli.Add(s.Artikli));
                try
                {
                    int racunId = 0;
                    using (var repo = new RacuniRepository())
                    {
                        racunId = repo.Add(racun);
                    }
                    if(racunId > 0)
                    {
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

        //Author : Filip Milohanović
        public bool AddInverse(Racun racun, List<StavkaRacuna> stavke)
        {

            foreach (var stavka in stavke)
            {
                stavka.kolcina *= -1;
                stavka.ukupno *= -1;

            }
            var stornoRacun = new Racun()
            {
                vrijeme_izdavanja = DateTime.Now,
                korisnik_id = racun.korisnik_id,
                cjena_bez_pdv = racun.cjena_bez_pdv * -1,
                pdv = racun.pdv * -1,
                popust = racun.popust * 1,
                nacin_placanja_id = racun.nacin_placanja_id,
                ukupno = racun.ukupno * -1,

            };
            return AddRacun(stornoRacun, stavke);
        }
    }
}
