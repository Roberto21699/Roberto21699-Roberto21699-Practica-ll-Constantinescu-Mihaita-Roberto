using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ferma.Models;
using Ferma.Repository;

namespace Ferma.Services
{
    public class ComandaService : BaseService
    {
        public ComandaService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Comanda> GetComenzi()
        {
            return repositoryWrapper.ComandaRepository.FindAll().ToList();
        }

        public List<Comanda> GetComenziByCondition(Expression<Func<Comanda, bool>> expression)
        {
            return repositoryWrapper.ComandaRepository.FindByCondition(expression).ToList();
        }

        public void AddComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Create(comanda);
        }

        public void UpdateComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Update(comanda);
        }

        public void DeleteComanda(Comanda comanda)
        {
            repositoryWrapper.ComandaRepository.Delete(comanda);
        }
    }
}
