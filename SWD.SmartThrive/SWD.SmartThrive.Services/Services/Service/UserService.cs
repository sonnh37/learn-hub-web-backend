﻿using AutoMapper;
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Repository;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SWD.SmartThrive.Services.Services.Service
{
    

    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;

        private readonly IRoleRepository _roleRepository;

        private readonly IConfiguration _configuration;

        private DateTime countDown = DateTime.Now.AddMinutes(30);

        public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, IHttpContextAccessor _httpContextAccessor) : base(mapper, unitOfWork, _httpContextAccessor)
        {
            _repository = unitOfWork.UserRepository;
            _roleRepository = unitOfWork.RoleRepository;
            _configuration = configuration;
        }

        public async Task<bool> AddUser(UserModel userModel)
        {
            var user = _mapper.Map<User>(userModel);
            var setUser = await SetBaseEntityToCreateFunc(user);
            
            return await _repository.Add(setUser);
        }

        public async Task<bool> UpdateUser(UserModel userModel)
        {
            var entity = await _repository.GetById(userModel.Id);

            if (entity == null)
            {
                return false;
            }
            _mapper.Map(userModel, entity);
            entity = await SetBaseEntityToUpdateFunc(entity);

            var user = _mapper.Map<User>(userModel);
            return await _repository.Update(user);
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
            {
                return false;
            }

            var user = _mapper.Map<User>(entity);
            return await _repository.Delete(user);
        }

        public async Task<List<UserModel>?> GetAllPagination(int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var users = await _repository.GetAllUser(pageNumber, pageSize, sortField, sortOrder);
            
            if (!users.Any())
            {
                return null;
            }

            return _mapper.Map<List<UserModel>>(users);
        }
        
        public async Task<List<UserModel>?> GetAll()
        {
            var users = await _repository.GetAll();
            
            if (!users.Any())
            {
                return null;
            }

            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task<(List<UserModel>?, long)> GetAllUserSearch(UserModel userModel, int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var user = _mapper.Map<User>(userModel);
            var usersWithTotalOrigin = await _repository.GetAllUserSearch(user, pageNumber, pageSize, sortField, sortOrder);

            if (!usersWithTotalOrigin.Item1.Any())
            {
                return (null, usersWithTotalOrigin.Item2);
            }
            var userModels = _mapper.Map<List<UserModel>>(usersWithTotalOrigin.Item1);

            return (userModels, usersWithTotalOrigin.Item2);
        }

        public async Task<UserModel> GetUser(Guid id)
        {
            // get user by id to get list student relate
            var query = _repository.GetQueryable();

            query = query.Where(m => m.Id == id);

            query = query.Include(m => m.Students);

            var user = await _repository.GetById(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<UserModel>(user);
        }

        public async Task<UserModel> Login(AuthModel authModel)
        {
            User userHasUsernameOrEmail = new User
            {
                Email = authModel.UsernameOrEmail,
                Username = authModel.UsernameOrEmail,
                Password = authModel.Password,
            };
            // check username or email
            User user = await _repository.FindUsernameOrEmail(userHasUsernameOrEmail);

            if (user == null)
            {
                return null;
            }

            // check password
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(authModel.Password, user.Password);
            if (!isPasswordValid)
            {
                return null;
            }

            UserModel userModel = _mapper.Map<UserModel>(user);

            return userModel;
        }

        public async Task<UserModel> Register(UserModel userModel)
        {
            userModel.Password = BCrypt.Net.BCrypt.HashPassword(userModel.Password);
            
            // get Role id by role name
            

            bool isUser = await AddUser(userModel);

            UserModel _userModel = await GetUserByEmailOrUsername(userModel);

            if (!isUser)
            {
                return null;
            }

            return _userModel;
        }

        public JwtSecurityToken CreateToken(UserModel userModel)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, userModel.Username),
            };
            // Conditional addition of claim based on function result
            if (!string.IsNullOrEmpty(userModel.Email))
            {
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, userModel.Email));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("Appsettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: creds,
                expires: countDown
                );

            return token;
        }

        public async Task<UserModel> GetUserByEmailOrUsername(UserModel userModel)
        {
            var user = await _repository.FindUsernameOrEmail(_mapper.Map<User>(userModel));
            return _mapper.Map<UserModel>(user);
        }
        
    }
}
