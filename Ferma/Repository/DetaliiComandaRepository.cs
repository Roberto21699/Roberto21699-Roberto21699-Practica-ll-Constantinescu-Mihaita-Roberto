using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public class DetaliiComandaRepository : RepositoryBase<DetaliiComanda>, IDetaliiComandaRepository
    {
        public DetaliiComandaRepository(FermaContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}