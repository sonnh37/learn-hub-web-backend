using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class SessionService : BaseService<Session>, ISessionService
    {
        private readonly ISessionRepository _repository;

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.SessionRepository;
        }

        public async Task<bool> AddSession(SessionModel sessionModel)
        {
            var session = _mapper.Map<Session>(sessionModel);
            return await _repository.AddSession(session);
        }

        public async Task<bool> UpdateSession(SessionModel sessionModel)
        {
            var session = _mapper.Map<Session>(sessionModel);
            return await _repository.UpdateSession(session);
        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var session = await _repository.GetSession(id);
            if (session != null)
            {
                session.IsDeleted = true;
                var isSession = await _repository.UpdateSession(session);

                if (isSession)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<SessionModel>> GetAllSession()
        {
            var sessions = await _repository.GetAllSession();

            if (sessions == null)
            {
                return null;
            }

            return _mapper.Map<List<SessionModel>>(sessions);
        }

        public async Task<List<SessionModel>> GetAllSessionByCourse(Guid id)
        {

            var sessions = await _repository.GetAllSessionByCouse(id);

            if (sessions == null)
            {
                return null;
            }

            return _mapper.Map<List<SessionModel>>(sessions);
        }

        public async Task<SessionModel> GetSession(Guid id)
        {
            var session = await _repository.GetSession(id);

            if (session == null)
            {
                return null;
            }

            return _mapper.Map<SessionModel>(session);
        }
    }
}
