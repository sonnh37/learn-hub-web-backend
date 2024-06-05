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
