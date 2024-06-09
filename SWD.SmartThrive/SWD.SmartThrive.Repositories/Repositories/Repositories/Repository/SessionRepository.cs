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
            var entity = await base.GetById(session.Id);

            if (entity != null)
            {
                return false;
            }

            base.Add(session);
            _context.SaveChanges();

            return true;
        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var entity = await base.GetById(id);

            if (entity == null)
            {
                return false;
            }
            base.Delete(entity);
            _context.SaveChanges();

            return true;
        }

        public async Task<List<Session>> GetAllSessions()
        {
            var sessions = await base.GetAll();
            return sessions;
        }

        public async Task<List<Session>> GetAllSessionsByCouse(Guid CourseId)
        {
            var sessions = base.GetQueryable(x => x.CourseId == CourseId);

            if (sessions.Any())
            {
                sessions = sessions.Where(x => !x.IsDeleted);
            }

            var results = await sessions.Include(x => x.Course).ToListAsync();

            return results;
        }

        public async Task<Session> GetSession(Guid id)
        {
            var session = await base.GetById(id);
            return session;
        }

        public async Task<bool> UpdateSession(Session session)
        {
            var entity = await base.GetById(session.Id);

            if (entity == null)
            {
                return false;
            }

            base.Update(entity);
            _context.SaveChanges();

            return true;
        }
    }
}
