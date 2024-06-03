using AutoMapper;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Model.RequestModel;
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
        private readonly IMapper _mapper;

        public UserSerrvice(IUserRepository _userRepositoy, IMapper mapper) {
        this.userRepo = _userRepositoy;
          _mapper = mapper;
        }

        public async Task<bool> AddUser(UserRequest user)
        {
  
               var s = _mapper.Map<User>(user);
                s.Status = true;
                
                return await userRepo.AddUser(s);
         
       
        }


        public async Task<User> GetUserById(Guid id)
        {
            return await userRepo.GetUserById(id);
        }
    }
}
