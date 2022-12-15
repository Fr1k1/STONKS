using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    partial class Primka
    {

        public override string ToString()
        {
            return id+ " " + ukupno +" "+ Dobavljac_id + " " + datum.ToString();
        }
    }
}
