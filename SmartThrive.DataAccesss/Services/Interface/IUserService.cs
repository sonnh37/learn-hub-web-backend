using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IUserService
    {
        public Task<bool> AddUser(User user);

        public Task<User> GetUserById(Guid id);

    }
}
