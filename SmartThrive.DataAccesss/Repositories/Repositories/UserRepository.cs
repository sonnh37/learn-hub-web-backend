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
    public class UserRepository : BaseRepository<User>,IUserRepository

    {
        private readonly STDbContext _context;
        public UserRepository(STDbContext context )  : base(context)
        {
            this._context = context;


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
