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

        public async Task<bool> AddSession(SessionModel SessionModel)
        {
            var Session = _mapper.Map<Session>(SessionModel);
            return await _repository.Add(Session);
        }

        public async Task<bool> UpdateSession(SessionModel SessionModel)
        {
            var entity = await _repository.GetById(SessionModel.Id);
            if (entity == null)
            {
                return false;
            }

            var Session = _mapper.Map<Session>(SessionModel);
            return await _repository.Update(Session);
        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var Session = _mapper.Map<Session>(entity);
            return await _repository.Delete(Session);
        }

        public async Task<List<SessionModel>> GetAllSession()
        {
            var Sessions = await _repository.GetAll();

            if (Sessions == null)
            {
                return null;
            }

            return _mapper.Map<List<SessionModel>>(Sessions);
        }

        public async Task<SessionModel> GetSession(Guid id)
        {
            var Session = await _repository.GetById(id);

            if (Session == null)
            {
                return null;
            }

            return _mapper.Map<SessionModel>(Session);
        }
    }
}
