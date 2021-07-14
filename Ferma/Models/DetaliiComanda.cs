using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Models
{
    public class DetaliiComanda
    {

        public int ProdusId { get; set; }
        public int ComandaId { get; set; }
        public int Cantitate { get; set; }
        public Produs Produs { get; set; }
        public Comanda Comanda { get; set; }

    }
}
