using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        private readonly STDbContext _context;

        public CourseRepository(STDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddCourse(Course course)
        {
            var queryable = await base.GetById(course.Id);

            if (!queryable.Any())
            {
                base.Add(course);
                _context.SaveChanges();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();
                if (entity != null)
                {
                    entity.IsDeleted = true;
                    base.Update(entity);
                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public async Task<List<Course>> GetAllCourse()
        {
            var queryable = await GetAll();

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<List<Course>> GetAllCourseByProvider(Guid id)
        {
            var queryable = base.GetQueryable(x => x.ProviderId == id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Provider).ToListAsync();

                return results;
            }

            return null;
        }

        public async Task<Course> GetCourse(Guid id)
        {
            var queryable = await base.GetById(id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                return entity;
            }

            return null;
        }

        public async Task<bool> UpdateCourse(Course course)
        {
            var queryable = await base.GetById(course.Id);

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var entity = queryable.FirstOrDefault();

                if (entity != null)
                {
                    _mapper.Map(course, entity);
                    base.Update(entity);

                    _context.SaveChanges();

                    return true;
                }
            }

            return false;
        }

        public async Task<List<Course>> SearchCourse(string name)
        {
            var queryable = base.GetQueryable(x => x.CourseName.StartsWith(name) || x.Id.Equals(name));

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            if (queryable.Any())
            {
                var results = await queryable.Include(x => x.Provider).ToListAsync();

                return results;
            }

            return null;
        }

    }
}
