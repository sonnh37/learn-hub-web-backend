using AutoMapper;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using ST.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;

        public UserService(IUserRepository _userRepositoy, IMapper _mapper)
        {
            this.userRepo = _userRepositoy;
            this.mapper = _mapper;
        }

        public async Task<bool> Add(UserModel user)
        {
            try
            {
                return await userRepo.Add(mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        public async Task<bool> Delete(Guid id)
        {
            try
            {
                return await userRepo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> GetAll()
        {
            try
            {
                var users = await userRepo.GetAll();
                return mapper.Map<List<UserModel>>(users) ;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetById(Guid id)
        {
            try
            {
                var user = await userRepo.GetById(id);
                return mapper.Map<UserModel>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserModel>> GetByRoleId(Guid roleId)
        {
            try
            {
                var users = await userRepo.GetByRoleId(roleId);
                return mapper.Map<List<UserModel>>(users);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            try
            {
                var user = await userRepo.GetUserByEmail(email);
                return mapper.Map<UserModel>(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      

        public async Task<bool> Update(UserModel user)
        {
            try
            {
                return await userRepo.Update(mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdatePassword(string email, string password)
        {
            try
            {
                return await userRepo.UpdatePassword(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
    }
}
