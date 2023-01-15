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

        /*
        public int GetIdForNewRacun()
        {
            return GetRacuni().Count + 1;
        }*/

        public List<Racun> GetRacuniByDate(DateTime date)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByDate(date).ToList();
            }
        }

        public List<Racun> GetRacuniFilter(int id)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByNacinPlacanja(id).ToList();
            }
        }

        public int GetRacuniByNacinPlacanja(int id)
        {
            using (var repo = new RacuniRepository())
            {
                return repo.GetByNacinPlacanja(id).ToList().Count();
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
                korisnik_id = racun.korisnik_id,   //TODO change to logged user
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
