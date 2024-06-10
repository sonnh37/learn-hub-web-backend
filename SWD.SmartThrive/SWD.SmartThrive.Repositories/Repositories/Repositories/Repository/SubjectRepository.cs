using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(STDbContext context) : base(context)
        {
        }
    }
}
