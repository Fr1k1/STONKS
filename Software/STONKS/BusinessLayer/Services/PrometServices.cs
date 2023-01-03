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


        public double CalculateCash(DateTime date, bool withDiscount = false)
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

        public double CalculateCard(DateTime date, bool withDiscount = false)
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
    }
}
