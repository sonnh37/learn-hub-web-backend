using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface ISessionService
    {
        Task<bool> AddSession(SessionModel SessionModel);
        Task<bool> DeleteSession(Guid id);
        Task<List<SessionModel>> GetAllSession();
        Task<SessionModel> GetSession(Guid id);
        Task<bool> UpdateSession(SessionModel SessionModel);
    }
}
