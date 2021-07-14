using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Models
{
    public class Produs
    {
        public int ProdusId { get; set; }
        public string Denumire { get; set; }
        public int Pret { get; set; }
        public ICollection<DetaliiComanda> DetaliiComenzi { get; set; }
    }
}
