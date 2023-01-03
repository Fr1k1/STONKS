using DataAccessLayer.Repositories;
using EntitiesLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PrometServices
    {

        public double CalculateTax(DateTime date)
        {
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double tax = 0;
            foreach (var r in racuni)
            {
                tax += r.pdv;
            }
            return tax;
        }

            public double CalculateCash(DateTime date)
        {
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double total = 0;
            foreach(var r in racuni)
            {
                if (r.NaciniPlacanja.naziv == "Gotovina")
                {
                        total += r.ukupno;
                }
                
            }
            return total;
        }

        public double CalculateCard(DateTime date)
        {
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double total = 0;
            foreach (var r in racuni)
            {
                if (r.NaciniPlacanja.naziv == "Karticno")
                {
                        total += r.ukupno;
                }
            }
            return total;
        }

        public double CalculateCardDiscount(DateTime date)
        {
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double total = 0;
            foreach (var r in racuni)
            {
                if (r.NaciniPlacanja.naziv == "Karticno")
                {
                        total +=r.popust.GetValueOrDefault(0.0);

                }
            }
            return total;
        }

        public double CalculateCashDiscount(DateTime date)
        {
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double total = 0;
            foreach (var r in racuni)
            {
                if (r.NaciniPlacanja.naziv == "Gotovina")
                {
                    total += r.popust.GetValueOrDefault(0.0);

                }
            }
            return total;
        }

        public Dictionary<Korisnik, double> GetTraficByEmployees(DateTime date)
        {
            Dictionary<Korisnik, double> totalPerEmployee = new Dictionary<Korisnik, double>();
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);


            foreach (var r in racuni)
            {

                if (totalPerEmployee.ContainsKey(r.Korisnici))
                {
                    totalPerEmployee[r.Korisnici] += r.ukupno;
                }
                else
                {
                    totalPerEmployee.Add(r.Korisnici, r.ukupno);
                }
            }
            return totalPerEmployee;
        }

        public bool isZDone(DateTime date)
        {
            using (var repo = new PrometRepository())
            {
                return repo.GetByDate(date).ToList().Count > 0;
            }
        }

        public bool CreateZ(Korisnik korisnik = null)//remove null later
        {
            using (var repo = new PrometRepository())
            {
                Promet p = new Promet() { datum_vrijeme = DateTime.Now, korisnik_id = 1 }; //TODO change to actual user;
                return repo.Add(p) > 0;
            }
        }
    }
}
