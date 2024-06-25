using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SWD.SmartThrive.Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Services.Interface
{
    public interface IStudentService
    {
        Task<bool> Add(StudentModel student);
        Task<bool> Update(StudentModel student);
        Task<bool> Delete(Guid id);
        Task<List<StudentModel>> GetAll();
        Task<List<StudentModel>> GetAll(int pageNumber, int pageSize, string orderBy);
        Task<List<StudentModel>> GetStudentsByUserId(Guid id);
        Task<StudentModel> GetById(Guid id);
    }
}
