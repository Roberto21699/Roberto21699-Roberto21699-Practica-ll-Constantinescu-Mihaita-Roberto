using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ferma.Models;

namespace Ferma.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FermaContext FermaContext { get; set; }

        public RepositoryBase(FermaContext repositoryContext)
        {
            this.FermaContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return this.FermaContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.FermaContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.FermaContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.FermaContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.FermaContext.Set<T>().Remove(entity);
        }
    }
}
