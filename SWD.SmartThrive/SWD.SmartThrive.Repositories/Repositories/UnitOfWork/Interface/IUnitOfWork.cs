
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ICourseRepository CourseRepository { get; }
        ICourseXPackageRepository CourseXPackageRepository { get; }
        ILocationRepository LocationRepository { get; }
        IOrderRepository OrderRepository { get; }
        IPackageRepository PackageRepository { get; }
        IRoleRepository RoleRepository { get; }
        ISessionRepository SessionRepository { get; }
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }
        IProviderRepository ProviderRepository { get; }
    }
}
