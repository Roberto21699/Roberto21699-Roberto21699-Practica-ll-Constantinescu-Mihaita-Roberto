using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Ferma.Models
{
    public class Comanda
    {
        public int ComandaId { get; set; }
        public string Data { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<DetaliiComanda> DetaliiComenzi { get; set; }
    }
}
