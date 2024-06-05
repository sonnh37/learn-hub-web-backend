
using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services.Interface
{
    public interface ISessionService
    {

        public Task<bool> AddSession(SessionModel session);
        public Task<bool> UpdateSession(SessionModel session);
        public Task<bool> DeleteSession(Guid id);

        public Task<SessionModel> GetSession(Guid id);

        public Task<IEnumerable<SessionModel>> GetAllSessions();


    }
}
