using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ISessionRepository : IBaseRepository<Session>
    {
        public Task<Session> GetSession(Guid id);

        public Task<List<Session>> GetAllSession();

        public Task<List<Session>> GetAllSessionByCouse(Guid CourseId);

        public Task<List<Session>> SearchSessionByIdOrName(string search);
    }
}
