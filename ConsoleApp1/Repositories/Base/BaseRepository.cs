using Microsoft.EntityFrameworkCore;
using ST.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartThrive.DataAccess.Repositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly STDbContext _context;
        public BaseRepository(STDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(TEntity entity)
        {
            try
            {
                await _context.AddAsync(entity);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var e = await GetById(id);
                _context.Remove<TEntity>(e);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<IList<TEntity>> GetAll()
        {
            try
            {
               return await _context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<TEntity> GetById(Guid id)
        {
            try
            {
                var e = await GetById(id);
                return e;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> Update(TEntity entity)
        {
            try
            {
                _context.Update<TEntity>(entity);
                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

       
    }
}
