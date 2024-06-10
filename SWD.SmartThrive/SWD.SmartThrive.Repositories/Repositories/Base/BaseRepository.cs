using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using System.Linq.Expressions;

namespace SWD.SmartThrive.Repositories.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;
        protected readonly IMapper _mapper;

        public BaseRepository(DbContext dbContext)
        {
            _context = dbContext;
        }

        public BaseRepository(DbContext dbContext, IMapper mapper) : this(dbContext)
        {
            _mapper = mapper;
        }

        #region DbSet
        protected DbSet<TEntity> DbSet
        {
            get
            {
                var dbSet = GetDbSet<TEntity>();
                return dbSet;
            }
        }
        
        protected DbSet<T> GetDbSet<T>() where T : BaseEntity
        {
            var dbSet = _context.Set<T>();
            return dbSet;
        }
        #endregion

        #region GetQueryable(CancellationToken) + GetQueryable() + GetQueryable(Expression<Func<TEntity, bool>>)

        public IQueryable<TEntity> GetQueryable(CancellationToken cancellationToken = default)
        {
            CheckCancellationToken(cancellationToken);
            IQueryable<TEntity> queryable = GetQueryable<TEntity>();
            return queryable;
        }

        public IQueryable<T> GetQueryable<T>()
            where T : BaseEntity
        {
            IQueryable<T> queryable = GetDbSet<T>();
            return queryable;

        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> queryable = GetQueryable<TEntity>();
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }
            return queryable;
        }

        #endregion

        #region CheckCancellationToken(CancellationToken)

        public virtual void CheckCancellationToken(CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException("Request was cancelled");
        }
        #endregion

        #region Add(TEntity) + AddRange(List<TEntity>)
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(List<TEntity> entities)
        {
            if (entities.Any())
            {
                DbSet.AddRange(entities);
            }
        }
        #endregion

        #region Update(TEntity) + UpdateRange(List<TEntity>)
        public void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public void UpdateRange(List<TEntity> entities)
        {
            if (entities.Any())
            {
                DbSet.UpdateRange(entities);
            }
        }
        #endregion

        #region Delete(TEntity) + DeleteRange(List<TEntity>)
        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            DbSet.Update(entity);
        }

        public void DeleteRange(List<TEntity> entities)
        {
            entities.Where(e => e.IsDeleted == false ? e.IsDeleted = true : e.IsDeleted = false);
            DbSet.UpdateRange(entities);
        }
        #endregion

        #region GetAll(CancellationToken)
        public async Task<IQueryable<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable(cancellationToken);
            return queryable;
        }


        #endregion

        #region GetById(Guid) + GetByIds(List<Guid>)
        public virtual async Task<IQueryable<TEntity>> GetById(Guid id)
        {
            var queryable = GetQueryable(x => x.Id == id);

            return queryable;
        }

        public virtual async Task<IQueryable<TEntity>> GetAllById(List<Guid> id)
        {
            var queryable = GetQueryable(x => id.Contains(x.Id));

            return queryable;
        }
        #endregion

        #region GetTotalCount()
        public async Task<long> GetTotaCount()
        {
            var result = await GetQueryable().LongCountAsync();
            return result;
        }
        #endregion
    }
}
