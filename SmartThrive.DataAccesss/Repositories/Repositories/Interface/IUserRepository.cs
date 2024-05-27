using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Repositories.Interface
{
    public interface IUserRepository
    {

        public Task<User> GetUserById(Guid id);

        public Task<bool> AddUser(User user);
    }
}
