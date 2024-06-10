using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ISessionRepository : IBaseRepository
    {
        public Task<bool> AddSession(Session session);

        public Task<bool> UpdateSession(Session session);

        public Task<bool> DeleteSession(Guid id);

        public Task<Session> GetSession(Guid id);

        public Task<List<Session>> GetAllSession();

        public Task<List<Session>> GetAllSessionByCouse(Guid CourseId);
    }
}
