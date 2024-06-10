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

        public async Task<bool> AddUser(User user)
        {
            var queryable = await base.GetById(user.Id);

            if (!queryable.Any())
            {
                base.Add(user);
                _context.SaveChanges();
                return true; 
            }

            return false;
        }

        public async Task<bool> DeleteUser(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    base.Update(entity);
                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
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

        public async Task<List<User>> GetAllUser()
        {
            var queryable = await GetAll();

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<User> GetUser(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                return entity;
            }

            return null;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var queryable = await base.GetById(user.Id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                if (entity != null)
                {
                    _mapper.Map(user, entity);
                    base.Update(entity);

                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
