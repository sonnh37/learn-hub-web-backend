using SmartThrive.DataAccess.Repositories.Base;
using ST.Entities.Data.Table;
using ST.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Repositories.Interface
{
    public interface IUserRepository: IBaseRepository<User>
    {
        public Task<List<User>> GetByRoleId(Guid roleId);
        public Task<User> GetUserByEmail(string email);
        //public Task<User> Login(string username, string password);
        public Task<bool> UpdatePassword(string email, string password);
    }
}
