using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<List<Student>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy);
        Task<(List<Student>, long)> Search(Student student, int pageNumber, int pageSize, string orderBy);
    }
}
