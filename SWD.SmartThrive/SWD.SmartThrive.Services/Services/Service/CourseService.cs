using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _repository;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> AddCourse(CourseModel course)
        {
            return await _repository.AddCourse(_mapper.Map<Course>(course));
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

        public Task<List<CourseModel>> GetAllCourse()
        {
            throw new NotImplementedException();
        }

        public async Task<List<CourseModel>> GetAllCoursesByProvider(Guid id)
        {
            // kiem tra id provider 

            var courses = await _repository.GetAllCoursesByProvider(id);

            if (!courses.Any())
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }

        public async Task<CourseModel> GetCourse(Guid id)
        {
            return _mapper.Map<CourseModel>(await _repository.GetCourse(id));
        }

        public async Task<List<CourseModel>> SearchCourse(string name)
        {
            var courses = await _repository.SearchCourse(name);

            if (!courses.Any())
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }

        public async Task<bool> UpdateCourse(CourseModel course)
        {

            return await _repository.UpdateCourse(_mapper.Map<Course>(course));


        }
    }
}
