using AutoMapper;
using SmartThrive.DataAccess.Repositories.Repositories.Interface;
using SmartThrive.DataAccesss.Model.RequestModel;
using SmartThrive.DataAccesss.Services.Interface;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccesss.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper )
        {
            _repository = repository;
            _mapper = mapper;
        
        }
        public async Task<bool> AddSession(SessionModel session)
        {
            var s = _mapper.Map<Session>( session );
            return  await _repository.AddSession(s);
        }

        public async Task<bool> DeleteSession(Guid id)
        {
            return await _repository.DeleteSession(id);
        }

        public async Task<IEnumerable<SessionModel>> GetAllSessions()
        {
            var s = await _repository.GetAllSessions();
            return _mapper.Map<List<SessionModel>>(s);
        }

        public async Task<SessionModel> GetSession(Guid id)
        {
           var s = await _repository.GetSession(id);
            return _mapper.Map<SessionModel>( s );
        }

        public async Task<bool> UpdateSession(SessionModel session)
        {
            var s = _mapper.Map<Session>(session);
            return await _repository.UpdateSession(s);
        }
    }
}
