using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ferma.Models;
using Ferma.Repository;

namespace Ferma.Services
{
    public class ProdusService : BaseService
    {
        public ProdusService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Produs> GetProduse()
        {
            return repositoryWrapper.ProdusRepository.FindAll().ToList();
        }

        public List<Produs> GetProduseByCondition(Expression<Func<Produs, bool>> expression)
        {
            return repositoryWrapper.ProdusRepository.FindByCondition(expression).ToList();
        }

        public void AddProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Create(produs);
        }

        public void UpdateProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Update(produs);
        }

        public void DeleteProdus(Produs produs)
        {
            repositoryWrapper.ProdusRepository.Delete(produs);
        }
    }
}
