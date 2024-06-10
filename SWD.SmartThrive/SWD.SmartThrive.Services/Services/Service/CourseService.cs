using AutoMapper;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Repositories.Repositories.Repositories.Interface;
using SWD.SmartThrive.Repositories.Repositories.UnitOfWork.Interface;
using SWD.SmartThrive.Services.Base;
using SWD.SmartThrive.Services.Model;
using SWD.SmartThrive.Services.Services.Interface;

namespace SWD.SmartThrive.Services.Services.Service
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly ICourseRepository _repository;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper) : base(mapper, unitOfWork)
        {
            _repository = unitOfWork.CourseRepository;
        }

        public async Task<bool> AddCourse(CourseModel courseModel)
        {
            var course = await _repository.GetCourse(courseModel.Id);

            if (course != null)
            {
                return false;
            }

            var _course = _mapper.Map<Course>(courseModel);
            _course.Id = Guid.NewGuid();
            _repository.Add(_course);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> UpdateCourse(CourseModel courseModel)
        {
            var course = await _repository.GetCourse(courseModel.Id);

            if (course == null)
            {
                return false;
            }

            _mapper.Map(courseModel, course);
            _repository.Update(course);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var course = await _repository.GetCourse(id);

            if (course == null)
            {
                return false;
            }

            _repository.Delete(course);
            var saveChanges = await _unitOfWork.SaveChanges();

            return saveChanges ? true : false;
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
