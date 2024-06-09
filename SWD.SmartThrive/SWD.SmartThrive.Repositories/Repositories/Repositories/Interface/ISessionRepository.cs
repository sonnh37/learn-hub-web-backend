using SWD.SmartThrive.Repositories.Data.Table;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ISessionRepository
    {
        public Task<bool> AddSession(Session session);

        public Task<bool> UpdateSession(Session session);

        public Task<bool> DeleteSession(Guid id);

        public Task<Session> GetSession(Guid id);

        public Task<List<Session>> GetAllSessions();

        public Task<List<Session>> GetAllSessionsByCouse(Guid CourseId);
    }
}
