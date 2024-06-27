using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Interface
{
    public interface ISubjectRepository: IBaseRepository<Subject>
    {
        Task<List<Subject>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy);
        Task<(List<Subject>, long)> Search(Subject subject, int pageNumber, int pageSize, string orderBy);
        Task<List<Subject>> GetByCategoryId(Guid id);
    }
}
