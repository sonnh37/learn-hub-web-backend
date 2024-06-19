using SWD.SmartThrive.Repositories.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Model
{
    public class RoleModel : BaseModel
    {
        public string? RoleName { get; set; }

        public IList<UserModel>? Users { get; set; }
    }
}
