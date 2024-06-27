using Microsoft.EntityFrameworkCore;
using SWD.SmartThrive.Repositories.Data;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Base;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;

namespace SWD.SmartThrive.Repositories.Repositories.Repositories.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(STDbContext context) : base(context)
        {
        }

        public async Task<Role> GetRoleByName(string name)
        {
            var queryable = base.GetQueryable(x => x.RoleName.ToLower().Trim() == name.ToLower().Trim());

            if (queryable.Any())
            {
                queryable = queryable.Where(x => !x.IsDeleted);
            }

            return await queryable.FirstOrDefaultAsync();
        }
    }
}
