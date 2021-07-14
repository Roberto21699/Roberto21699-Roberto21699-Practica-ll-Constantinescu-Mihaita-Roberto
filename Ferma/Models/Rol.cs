using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Models
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Tip { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
