using AutoMapper;
using ST.Entities.Data.Table;
using SWD.DataAccesss.Model;
using SWD.DataAccesss.Services.Interface;
using SWD.Entities.Repositories.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWD.DataAccesss.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper ) {
        _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> AddCourse(CourseModel course)
        {
            return await _repository.AddCourse(_mapper.Map<Course>( course));
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var s = await _repository.GetCourse(id);
            if (s != null)
            {
                s.IsDeleted = true;
                var order = await _repository.UpdateCourse(s);
                if (order)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public Task<IEnumerable<CourseModel>> GetAllCourse()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CourseModel>> GetAllCoursesByProvider(Guid id)
        {
            // kiem tra id provider 

            var s = await _repository.GetAllCoursesByProvider(id);
            return _mapper.Map<IEnumerable<CourseModel>>(s);
        }

        public async Task<CourseModel> GetCourse(Guid id)
        {
           return _mapper.Map<CourseModel>(await _repository.GetCourse(id));
        }

        public async Task<IEnumerable<CourseModel>> SearchCourse(string name)
        {
           var s = await _repository.SearchCourse(name);
            return _mapper.Map<IEnumerable<CourseModel>>(s);
        }

        public async Task<bool> UpdateCourse(CourseModel course)
        {
           
            return await _repository.UpdateCourse(_mapper.Map<Course>(course));


        }
    }
}
