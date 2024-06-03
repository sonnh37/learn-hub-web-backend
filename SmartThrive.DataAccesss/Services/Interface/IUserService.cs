using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccess.Repositories.Base;
using ST.Entities.Data.Table;
using ST.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface IUserService
    {
        public Task<List<UserModel>> GetAll();
        public Task<UserModel> GetById(Guid id);
        public Task<bool> Add(UserModel user);
        public Task<bool> Update(UserModel user);
        public Task<bool> Delete(Guid id);
        public Task<List<UserModel>> GetByRoleId(Guid roleId);
        public Task<UserModel> GetUserByEmail(string email);
        //public Task<User> Login(string username, string password);
        public Task<bool> UpdatePassword(string email, string password);
        public Task<bool> AddUser(UserRequest user);

        public Task<User> GetUserById(Guid id);

    }
}
