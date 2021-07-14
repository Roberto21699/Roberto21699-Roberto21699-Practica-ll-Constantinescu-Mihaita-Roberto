using Restaurant.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public interface IRepositoryWrapper
    {
       IComandaRepository ComandaRepository { get; }
       IUserRepository UserRepository { get; }
       IRolRepository RolRepository { get; }
       IProdusRepository ProdusRepository { get; }
        INotaRepository NotaRepository { get; }
        IDetaliiComandaRepository DetaliiComandaRepository { get; }

        void Save();
    }
}
