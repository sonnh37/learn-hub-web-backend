using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly STDbContext _context;

        public UserRepository(STDbContext context) : base(context)
        {
            _context = context;
        }
        
        public async Task<User> FindUsernameOrEmail(User user)
        {
            var queryable = base.GetQueryable();

            // Apply base filtering: not deleted
            queryable = queryable.Where(entity => !entity.IsDeleted);

            // Check Username or email
            if (!string.IsNullOrEmpty(user.Username) || !string.IsNullOrEmpty(user.Email))
            {
                queryable = queryable.Where(entity => user.Username.ToLower() == entity.Username.ToLower()
                                            || user.Email.ToLower() == entity.Email.ToLower()
                );
            }

            queryable = queryable.Include(entity => entity.Role);

            // Execute the query asynchronously
            var result = await queryable.SingleOrDefaultAsync();

            return result;
        }
        
    }
}
