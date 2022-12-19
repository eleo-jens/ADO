using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAD22_ADO_Exo2.Models
{
    class Representation
    {
        public int id { get; set; }
        public int idSpectacle { get; set; }
        public DateTime dateRepresentation { get; set; }
        public DateTime heureRepresentation { get; set; }
    }
}
