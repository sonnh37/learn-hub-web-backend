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

        public async Task<List<User>> GetAllUserSearch(User user)
        {
            var queryable = base.GetQueryable(m => m.IsDeleted == user.IsDeleted);

            if (!queryable.Any())
            {
                return null;
            }

            queryable = queryable.Where(m =>
            (
            (string.IsNullOrEmpty(user.Username) || m.Username.ToLower().Trim() == user.Username.ToLower().Trim()) &&
            (string.IsNullOrEmpty(user.FullName) || m.FullName.ToLower().Trim().Contains(user.FullName.ToLower().Trim())) &&
            (string.IsNullOrEmpty(user.Email) || m.Email.ToLower().Trim() == user.Email.ToLower().Trim()) &&
            (!user.DOB.HasValue || m.DOB.Value.Date == user.DOB.Value.Date) &&
            (string.IsNullOrEmpty(user.Address) || m.Address.ToLower().Trim().Contains(user.Address.ToLower().Trim())) &&
            (string.IsNullOrEmpty(user.Gender) || m.Gender.ToLower().Trim() == user.Gender.ToLower().Trim()) &&
            (string.IsNullOrEmpty(user.Phone) || m.Phone.ToLower().Trim().Contains(user.Phone.ToLower().Trim())) &&
            (!user.Status.HasValue || m.Status == user.Status) &&
            (user.RoleId == Guid.Empty || m.RoleId == user.RoleId) &&
            (user.LocationId == Guid.Empty || m.LocationId == user.LocationId)
            ));

            var users = await queryable.ToListAsync();

            return users;
        }

    }
}
