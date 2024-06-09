using SWD.SmartThrive.Repositories.Data.Table;

namespace SWD.SmartThrive.Repositories.Repositories.Base
{
    public interface IBaseRepository
    {
    }
    public interface IBaseRepository<TEntity> : IBaseRepository
        where TEntity : BaseEntity
    {
        Task<bool> Check(Guid id);

        IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default);

        Task<long> GetTotaCount();

        Task<List<TEntity>> GetAll(CancellationToken cancellationToken = default);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetByIds(List<Guid> ids);

        void Add(TEntity entity);
        void AddRange(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        void CheckCancellationToken(CancellationToken cancellationToken = default);

    }
}
