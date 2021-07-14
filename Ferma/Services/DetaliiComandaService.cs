using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ferma.Models;
using Ferma.Repository;

namespace Ferma.Services
{
    public class DetaliiComandaService : BaseService
    {
        public DetaliiComandaService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<DetaliiComanda> GetDetaliiComenzi()
        {
            return repositoryWrapper.DetaliiComandaRepository.FindAll().ToList();
        }

        public List<DetaliiComanda> GetDetaliiComenziByCondition(Expression<Func<DetaliiComanda, bool>> expression)
        {
            return repositoryWrapper.DetaliiComandaRepository.FindByCondition(expression).ToList();
        }

        public void AddDetaliiComanda(DetaliiComanda detaliicomanda)
        {
            repositoryWrapper.DetaliiComandaRepository.Create(detaliicomanda);
        }

        public void UpdateDetaliiComanda(DetaliiComanda detaliicomanda)
        {
            repositoryWrapper.DetaliiComandaRepository.Update(detaliicomanda);
        }

        public void DeleteDetaliiComanda(DetaliiComanda detaliicomanda)
        {
            repositoryWrapper.DetaliiComandaRepository.Delete(detaliicomanda);
        }
    }
}
