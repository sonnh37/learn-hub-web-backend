using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface
{
    public interface IBaseUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> GetRepositoryByEntity<TEntity>() where TEntity : BaseEntity;

        TRepository GetRepository<TRepository>() where TRepository : IBaseRepository;

        Task<bool> SaveChanges(CancellationToken cancellationToken = default);
    }
}
