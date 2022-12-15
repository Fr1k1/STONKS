using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer.Entities
{
    partial class StavkaPrimke
    {
        public override bool Equals(object obj)
        {
            return obj is StavkaPrimke primke &&
                   artikl_id == primke.artikl_id;
        }

        public override int GetHashCode()
        {
            return 1500605918 + artikl_id.GetHashCode();
        }

        public override string ToString()
        {
            return Artikli.ToString();
        }
    }
}
