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
        public async Task<bool> Add(TEntity entity)
        {
            DbSet.Add(entity);

            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AddRange(List<TEntity> entities)
        {
            if (entities.Any())
            {
                DbSet.AddRange(entities);
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Update(TEntity) + UpdateRange(List<TEntity>)
        public async Task<bool> Update(TEntity entity)
        {
            DbSet.Update(entity);
            var result = await _context.SaveChangesAsync();

            if ( result > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateRange(List<TEntity> entities)
        {
            if (entities.Any())
            {
                DbSet.UpdateRange(entities);
            }
            var result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Delete(TEntity) + DeleteRange(List<TEntity>)
        public async Task<bool> Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            return await Update(entity);
        }

        public async Task<bool> DeleteRange(List<TEntity> entities)
        {
            entities.Where(e => e.IsDeleted == false ? e.IsDeleted = true : e.IsDeleted = false);
            DbSet.UpdateRange(entities);

            return await UpdateRange(entities);
        }
        #endregion

        #region GetAll(CancellationToken)
        public async Task<IList<TEntity>> GetAll(CancellationToken cancellationToken = default)
        {
            var queryable = GetQueryable(cancellationToken);
            var result = await queryable.Where(entity => !entity.IsDeleted).ToListAsync();
            return result;
        }


        #endregion

        #region GetById(Guid) + GetByIds(List<Guid>)
        public virtual async Task<TEntity> GetById(Guid id)
        {
            var queryable = GetQueryable(x => x.Id == id);
            var entity = await queryable.FirstOrDefaultAsync();

            return entity;
        }

        public virtual async Task<IList<TEntity>> GetAllById(List<Guid> id)
        {
            var queryable = GetQueryable(x => id.Contains(x.Id));
            var entity = await queryable.ToListAsync();

            return entity;
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
