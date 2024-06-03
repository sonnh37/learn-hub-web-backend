using SmartThrive.DataAccess.Repositories.Base;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using ST.Entities.Data;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Repositories
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        public SessionRepository(STDbContext context) : base(context)
        {

            
        }

        public async Task<bool> AddSession(Session session)
        {
            var s = await base.Add(session);
            return s;

        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var d = await base.Delete(id);
            return d;
        }

        public async Task<IEnumerable<Session>> GetAllSessions()
        {
            var a = await base.GetAll();
            return a;
        }

        public async Task<Session> GetSession(Guid id)
        {
            var g = await base.GetById(id);
            return g;
        }

        public async Task<bool> UpdateSession(Session session)
        {
           var u = await base.Update(session);
            return u;
        }
    }
}
