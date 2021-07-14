using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public class ComandaRepository : RepositoryBase<Comanda>, IComandaRepository
    {
        public ComandaRepository(FermaContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}