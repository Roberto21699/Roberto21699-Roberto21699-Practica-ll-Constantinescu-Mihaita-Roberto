using Ferma.Models;

namespace Ferma.Repository
{
    public class ProdusRepository : RepositoryBase<Produs>, IProdusRepository
    {
        public ProdusRepository(FermaContext FermaContext)
            : base(FermaContext)
        {
        }
    }
}
