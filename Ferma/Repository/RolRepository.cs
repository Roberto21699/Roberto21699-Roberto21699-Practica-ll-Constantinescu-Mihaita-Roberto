
using Ferma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public class RolRepository : RepositoryBase<Rol>, IRolRepository
    {
        public RolRepository(FermaContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}