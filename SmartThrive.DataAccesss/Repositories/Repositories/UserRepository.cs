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
    {
        private readonly STDbContext _context;
        public UserRepository(STDbContext context) : base(context)
        {
            //_context = context;
        }

        public async Task<List<User>> GetByRoleId(Guid roleId)
        {
            return await _context.Users.Where(u => u.RoleID == roleId).ToListAsync();
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> UpdatePassword(string email, string password)
        {
            var user = await GetUserByEmail(email);
            user.Password = password;
            _context.Update(user);
            if (await _context.SaveChangesAsync() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
