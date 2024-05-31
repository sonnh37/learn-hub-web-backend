using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services
{
    public class UserSerrvice : IUserService
    {
        private readonly IUserRepository userRepo;

        public UserSerrvice(IUserRepository _userRepositoy) {
        this.userRepo = _userRepositoy;
        }

        public async Task<bool> AddUser(User user)
        {
            var u = await userRepo.GetUserById(user.Id);
            if (u == null) {
                return await userRepo.AddUser(user);
            } 
            else { return false; }
       
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await userRepo.GetUserById(id);
        }
    }
}
