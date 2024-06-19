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

        public async Task<bool> AddSession(SessionModel packageModel)
        {
            var package = await _repository.GetSession(packageModel.Id);

            if (package != null)
            {
                return false;
            }

            var _package = _mapper.Map<Session>(packageModel);
            _package.Id = Guid.NewGuid();
            _repository.Add(_package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> UpdateSession(SessionModel packageModel)
        {
            var package = await _repository.GetSession(packageModel.Id);

            if (package == null)
            {
                return false;
            }

            _mapper.Map(packageModel, package);
            _repository.Update(package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> DeleteSession(Guid id)
        {
            var package = await _repository.GetSession(id);

            if (package == null)
            {
                return false;
            }

            _repository.Delete(package);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
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

        public async Task<List<SessionModel>> SearchModel(string search)
        {
            var queryable = await _repository.SearchSessionByIdOrName(search);

            if (queryable == null)
            {
                return null;
            }
            return _mapper.Map<List<SessionModel>>(queryable);
        }
    }
}
