using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Parola { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }
        public ICollection<Comanda> Comenzi { get; set; }
        public ICollection<Nota> Note { get; set; }
        
    }
}
