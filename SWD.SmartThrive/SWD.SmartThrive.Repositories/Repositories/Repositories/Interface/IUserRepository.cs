using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        public Task<bool> AddUser(User user);

        public Task<bool> UpdateUser(User user);

        public Task<bool> DeleteUser(Guid id);

        public Task<User> GetUser(Guid id);

        public Task<List<User>> GetAllUser();

        Task<User> FindUsernameOrEmail(User user);

    }
}
