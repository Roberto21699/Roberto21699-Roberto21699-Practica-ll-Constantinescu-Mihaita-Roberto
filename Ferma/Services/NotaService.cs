using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ferma.Models;
using Ferma.Repository;

namespace Ferma.Services
{
    public class NotaService : BaseService
    {
        public NotaService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Nota> GetNote()
        {
            return repositoryWrapper.NotaRepository.FindAll().ToList();
        }

        public List<Nota> GetNoteByCondition(Expression<Func<Nota, bool>> expression)
        {
            return repositoryWrapper.NotaRepository.FindByCondition(expression).ToList();
        }

        public void AddNota(Nota nota)
        {
            repositoryWrapper.NotaRepository.Create(nota);
        }

        public void UpdateNota(Nota nota)
        {
            repositoryWrapper.NotaRepository.Update(nota);
        }

        public void DeleteNota(Nota nota)
        {
            repositoryWrapper.NotaRepository.Delete(nota);
        }
    }
}
