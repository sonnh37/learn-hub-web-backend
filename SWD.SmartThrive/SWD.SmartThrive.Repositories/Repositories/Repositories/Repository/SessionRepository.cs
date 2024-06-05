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
            var s = await Add(session);
            return s;

        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var d = await Delete(id);
            return d;
        }

        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            var a = await GetAll();
            return a;
        }

        public async Task<IEnumerable<Session>> GetAllSessionsByCouse(Guid CourseId)
        {
            var session = await _context.Sessions.Where(x => x.CourseId == CourseId).ToListAsync();
            return session;
        }

        public async Task<Session> GetSession(Guid id)
        {
            var g = await GetById(id);
            return g;
        }

        public async Task<bool> UpdateSession(Session session)
        {
            var u = await Update(session);
            return u;
        }
    }
}
