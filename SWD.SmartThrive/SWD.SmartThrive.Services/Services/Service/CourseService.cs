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

        public async Task<bool> AddCourse(CourseModel courseModel)
        {
            var course = _mapper.Map<Course>(courseModel);
            return await _repository.AddCourse(course);
        }

        public async Task<bool> UpdateCourse(CourseModel courseModel)
        {
            var course = _mapper.Map<Course>(courseModel);
            return await _repository.UpdateCourse(course);
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var course = await _repository.GetCourse(id);
            if (course != null)
            {
                course.IsDeleted = true;
                var isCourse = await _repository.UpdateCourse(course);

                if (isCourse)
                {
                    return true;
                }
            }
            return false;
        }

        public async Task<List<CourseModel>> GetAllCourse()
        {
            var courses = await _repository.GetAllCourse();

            if (courses == null)
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }

        public async Task<List<CourseModel>> GetAllCourseByProvider(Guid id)
        {

            var courses = await _repository.GetAllCourseByProvider(id);

            if (courses == null)
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }

        public async Task<CourseModel> GetCourse(Guid id)
        {
            var course = await _repository.GetCourse(id);

            if (course == null)
            {
                return null;
            }

            return _mapper.Map<CourseModel>(course);
        }

        public async Task<List<CourseModel>> SearchCourse(string name)
        {
            var courses = await _repository.SearchCourse(name);

            if (courses == null)
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }
        
    }
}
