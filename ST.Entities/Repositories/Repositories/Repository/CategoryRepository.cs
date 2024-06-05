using SmartThrive.DataAccess.Repositories.Base;

using ST.Entities.Data;
using ST.Entities.Data.Table;
using SWD.Entities.Repositories.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Repositories.Repositories.Repository
{
    public class CategoryRepository : BaseRepository<Provider>, ICategoryRepository
    {
        public CategoryRepository(STDbContext context) : base(context)
        {
        }
    }
}
