using SWD.SmartThrive.Repositories.Data.Entities;

namespace SWD.SmartThrive.Repositories.Repositories.Base
{
    public interface IBaseRepository
    {
    }
    public interface IBaseRepository<TEntity> : IBaseRepository
        where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default);

        Task<long> GetTotaCount();

        Task<IQueryable<TEntity>> GetAll(CancellationToken cancellationToken = default);

        Task<IQueryable<TEntity>> GetById(Guid id);

        Task<IQueryable<TEntity>> GetAllById(List<Guid> id);

        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        void CheckCancellationToken(CancellationToken cancellationToken = default);

    }
}
