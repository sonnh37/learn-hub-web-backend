using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> FindUsernameOrEmail(User user);
        Task<List<User>> GetAllUserSearch(User user, int pageNumber, int pageSize, string orderBy);
        Task<List<User>> GetAllUser(int pageNumber, int pageSize, string orderBy);
    }
}
