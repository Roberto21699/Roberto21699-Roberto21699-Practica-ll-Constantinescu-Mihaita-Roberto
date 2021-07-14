using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Ferma.Models;
using Ferma.Repository;

namespace Ferma.Services
{
    public class RolService : BaseService
    {
        public RolService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Rol> GetRoluri()
        {
            return repositoryWrapper.RolRepository.FindAll().ToList();
        }

        public List<Rol> GetRoluriByCondition(Expression<Func<Rol, bool>> expression)
        {
            return repositoryWrapper.RolRepository.FindByCondition(expression).ToList();
        }

        public void AddRol(Rol rol)
        {
            repositoryWrapper.RolRepository.Create(rol);
        }

        public void UpdateRol(Rol rol)
        {
            repositoryWrapper.RolRepository.Update(rol);
        }

        public void DeleteRol(Rol rol)
        {
            repositoryWrapper.RolRepository.Delete(rol);
        }
    }
}
