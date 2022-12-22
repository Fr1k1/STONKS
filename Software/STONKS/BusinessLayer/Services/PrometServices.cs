using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class PrometServices
    {
        public double CalculateTotal(DateTime date)
        {   
            RacuniServices racuniServices = new RacuniServices();
            var racuni = racuniServices.GetRacuniByDate(date);

            double total = 0;
            racuni.ForEach(r => total += r.ukupno);
            return total;
        }
    }
}
