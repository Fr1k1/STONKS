using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    public partial class Dobavljac
    {
        public Dobavljac(string naziv, string oIB, string adresa)
        {
            this.naziv = naziv;
            OIB = oIB;
            this.adresa = adresa;
        }

        public override string ToString()
        {
            return naziv;
        }
    }
}
