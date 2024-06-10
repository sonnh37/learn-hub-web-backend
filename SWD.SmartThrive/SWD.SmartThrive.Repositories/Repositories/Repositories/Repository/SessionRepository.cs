using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        private readonly STDbContext _context;
        public SessionRepository(STDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddSession(Session session)
        {
            var queryable = await base.GetById(session.Id);

            if (!queryable.Any())
            {
                base.Add(session);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteSession(Guid id)
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

        public async Task<List<Session>> GetAllSession()
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

        public async Task<List<Session>> GetAllSessionByCouse(Guid id)
        {
            var queryable = base.GetQueryable(x => x.CourseId == id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Course).ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<Session> GetSession(Guid id)
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

        public async Task<bool> UpdateSession(Session session)
        {
            var queryable = await base.GetById(session.Id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                if (entity != null)
                {
                    _mapper.Map(session, entity);
                    base.Update(entity);

                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }
    }
}
