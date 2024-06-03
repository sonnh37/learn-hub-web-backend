using Microsoft.EntityFrameworkCore;
using SmartThrive.DataAccess.Repositories.Base;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SQLitePCL;
using ST.Entities.Data;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    public class UserRepository : BaseRepository<User>,IUserRepository

    {
        private readonly STDbContext _context;
        public UserRepository(STDbContext context) : base(context)
        public UserRepository(STDbContext context )  : base(context)
        {
            this._context = context;

        public async Task<List<User>> GetByRoleId(Guid roleId)
        {
            return await _context.Users.Where(u => u.RoleID == roleId).ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        async Task<bool> IUserRepository.AddUser(User user)
        {
           await _context.Users.AddAsync(user);
            return await _context.SaveChangesAsync() > 0;
        }

        async Task<User> IUserRepository.GetUserById(Guid id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }
    }
}
