using modus.Core.Repositories;
using modus.Data.Repositories.Base;
using modus.Model.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modus.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base()
        {
        }
    }
}
