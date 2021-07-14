using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IComandaRepository _comanda;
        private IUserRepository _user;
        private IRolRepository _rol;
        private IProdusRepository _produs;
        private INotaRepository _nota;
        private IDetaliiComandaRepository _detaliicomanda;
        private FermaContext _repoContext;
        
        public IUserRepository UserRepository

        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }

                return _user;
            }
        }
       
        public IComandaRepository ComandaRepository

        {
            get
            {
                if (_comanda == null)
                {
                    _comanda = new ComandaRepository(_repoContext);
                }

                return _comanda;
            }
        }
        public IRolRepository RolRepository

        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(_repoContext);
                }

                return _rol;
            }
        }
        public IProdusRepository ProdusRepository

        {
            get
            {
                if (_produs == null)
                {
                    _produs = new ProdusRepository(_repoContext);
                }

                return _produs;
            }
        }
        public INotaRepository NotaRepository

        {
            get
            {
                if (_nota == null)
                {
                    _nota = new NotaRepository(_repoContext);
                }

                return _nota;
            }
        }
        public IDetaliiComandaRepository DetaliiComandaRepository

        {
            get
            {
                if (_detaliicomanda == null)
                {
                    _detaliicomanda = new DetaliiComandaRepository(_repoContext);
                }

                return _detaliicomanda;
            }
        }
        public RepositoryWrapper(FermaContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}

