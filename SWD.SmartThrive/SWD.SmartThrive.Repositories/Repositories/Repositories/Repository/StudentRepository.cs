using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(STDbContext context) : base(context)
        {
        }

        public IQueryable<Student> GetQueryablePaginationWithOrderBy(string orderBy)
        {
            // Sắp xếp trước 
            var queryable = base.GetQueryable();

            if (queryable.Any())
            {
                switch (orderBy.ToLower())
                {
                    case "studentname":
                        queryable = queryable.OrderBy(o => o.StudentName);
                        break;
                    case "gender":
                        queryable = queryable.OrderBy(o => o.Gender);
                        break;
                    default:
                        queryable = queryable.OrderBy(o => o.Id);
                        break;
                }
            }

            return queryable;
        }

        public async Task<List<Student>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            return await queryable.ToListAsync();
        }

        public async Task<(List<Student>, long)> Search(Student student, int pageNumber, int pageSize, string orderBy)
        {
            var queryable = this.GetQueryablePaginationWithOrderBy(orderBy);

            // Điều kiện lọc từng bước
            if (queryable.Any())
            {
                if (!string.IsNullOrEmpty(student.StudentName))
                {
                    queryable = queryable.Where(m => m.StudentName.ToLower().Trim().StartsWith(student.StudentName.ToLower().Trim()));
                }

                if (!string.IsNullOrEmpty(student.Gender))
                {
                    queryable = queryable.Where(m => m.Gender.ToLower().Trim().StartsWith(student.Gender.ToLower().Trim()));
                }

                if (student.UserId != Guid.Empty && student.UserId != null)
                {
                    queryable = queryable.Where(m => m.UserId == student.UserId);
                }
            }

            var totalOrigin = queryable.Count();

            // Lọc theo trang
            queryable = GetQueryablePagination(queryable, pageNumber, pageSize);

            var providers = await queryable.ToListAsync();

            return (providers, totalOrigin);
        }
    }

}
