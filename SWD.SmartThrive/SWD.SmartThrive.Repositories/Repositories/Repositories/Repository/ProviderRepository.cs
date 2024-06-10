using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class ProviderRepository : BaseRepository<Provider>, IProviderRepository
    {
        public ProviderRepository(STDbContext context) : base(context)
        {
        }
    }
}
