using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _repository;
        private readonly IMapper _mapper;

        public SessionService(ISessionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<bool> AddSession(SessionModel session)
        {
            var s = _mapper.Map<Session>(session);
            return await _repository.AddSession(s);
        }

        public async Task<bool> DeleteSession(Guid id)
        {

            var s = await _repository.GetSession(id);
            if (s != null)
            {
                s.IsDeleted = true;
                var order = await _repository.UpdateSession(s);
                if (order)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<List<SessionModel>> GetAllSessionByCourse(Guid courseid)
        {
            var sessions = await _repository.GetAllSessionsByCouse(courseid);

            if (!sessions.Any())
            {
                return null;
            }

            return _mapper.Map<List<SessionModel>>(sessions.ToList());

        }

        public async Task<List<SessionModel>> GetAllSessions()
        {
            var s = await _repository.GetAllSessions();
            return _mapper.Map<List<SessionModel>>(s);
        }

        public async Task<SessionModel> GetSession(Guid id)
        {
            var s = await _repository.GetSession(id);
            return _mapper.Map<SessionModel>(s);
        }

        public async Task<bool> UpdateSession(SessionModel session)
        {
            var s = _mapper.Map<Session>(session);
            return await _repository.UpdateSession(s);
        }
    }
}
