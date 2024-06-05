using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.Entities.Repositories.Repositories.Interface
{
    public interface ISessionRepository
    {
        public Task<bool> AddSession(Session session);
        public Task<bool> UpdateSession(Session session);

        public Task<bool> DeleteSession(Guid id);

        public  Task<Session> GetSession(Guid id);

        public  Task<IEnumerable<Session>> GetAllSessions();

        public Task<IEnumerable<Session>> GetAllSessionsByCouse(Guid CourseId);


    }
}
