using Ferma.Models;

namespace Ferma.Repository
{
    public class NotaRepository : RepositoryBase<Nota>, INotaRepository
    {
        public NotaRepository(FermaContext FermaContext)
            : base(FermaContext)
        {
        }
    }
}
