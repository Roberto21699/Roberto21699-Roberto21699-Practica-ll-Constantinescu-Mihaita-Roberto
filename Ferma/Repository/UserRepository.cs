
using Ferma.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferma.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(FermaContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}