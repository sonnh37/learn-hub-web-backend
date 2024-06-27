using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Repository;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _studentRepository = unitOfWork.StudentRepository;
        }
        public async Task<bool> Add(StudentModel model)
        {
            try
            {
                var student = _mapper.Map<Student>(model);
                var setStudent = await SetBaseEntityToCreateFunc(student);
                return await _studentRepository.Add(setStudent);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(StudentModel model)
        {
            try
            {
                return await _studentRepository.Delete(_mapper.Map<Student>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StudentModel>> GetAll()
        {
            return _mapper.Map<List<StudentModel>>(await _studentRepository.GetAll());
        }

        public async Task<List<StudentModel>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy)
        {
            try
            {
                return _mapper.Map<List<StudentModel>>(await _studentRepository.GetAllPaginationWithOrder(pageNumber, pageSize, orderBy));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<StudentModel> GetById(Guid id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                return _mapper.Map<StudentModel>(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<StudentModel>> GetStudentsByUserId(Guid id)
        {
            try
            {
                return _mapper.Map<List<StudentModel>>(await _studentRepository.GetStudentsByUserId(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(List<StudentModel>?, long)> Search(StudentModel model, int pageNumber, int pageSize, string orderBy)
        {
            var student = _mapper.Map<Student>(model);
            var studentsWithTotalOrigin = await _studentRepository.Search(student, pageNumber, pageSize, orderBy);

            if (!studentsWithTotalOrigin.Item1.Any())
            {
                return (null, studentsWithTotalOrigin.Item2);
            }
            var models = _mapper.Map<List<StudentModel>>(studentsWithTotalOrigin.Item1);

            return (models, studentsWithTotalOrigin.Item2);
        }

        public async Task<bool> Update(StudentModel model)
        {
            try
            {
                return await _studentRepository.Update(_mapper.Map<Student>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
