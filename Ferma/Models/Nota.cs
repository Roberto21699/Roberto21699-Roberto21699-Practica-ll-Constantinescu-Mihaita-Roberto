using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Models
{
    public class Nota
    {
        public int NotaId { get; set; }
        public string Data { get; set; }
        public int Total { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
