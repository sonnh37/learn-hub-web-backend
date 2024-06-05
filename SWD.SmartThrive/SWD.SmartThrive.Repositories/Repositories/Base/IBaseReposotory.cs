namespace SWD.SmartThrive.Repositories.Repositories.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<bool> Add(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(TEntity entity);

    }
}
