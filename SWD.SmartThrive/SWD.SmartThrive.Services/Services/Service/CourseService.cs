using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _repository = unitOfWork.CourseRepository;
        }

        public async Task<bool> AddCourse(CourseModel CourseModel)
        {
            var Course = _mapper.Map<Course>(CourseModel);
            var course = await SetBaseEntityToCreateFunc(Course);
            return await _repository.Add(course);
        }

        public async Task<bool> UpdateCourse(CourseModel courseModel)
        {
            var entity = await _repository.GetById(courseModel.Id);

            if (entity == null)
            {
                return false;
            }
            _mapper.Map(courseModel, entity);
            entity = await SetBaseEntityToUpdateFunc(entity);

            return await _repository.Update(entity);
        }

        public async Task<bool> DeleteCourse(Guid id)
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return false;
            }

            var Course = _mapper.Map<Course>(entity);
            return await _repository.Delete(Course);
        }

        public async Task<List<CourseModel>> GetAllCourse()
        {
            var Courses = await _repository.GetAll();

            if (!Courses.Any())
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(Courses);
        }

        public async Task<CourseModel> GetCourse(Guid id)
        {
            var Course = await _repository.GetById(id);

            if (Course == null)
            {
                return null;
            }

            return _mapper.Map<CourseModel>(Course);
        }

        public async Task<List<CourseModel>?> GetAllPagination(int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var courses = await _repository.GetAllCourse(pageNumber, pageSize, sortField, sortOrder);

            if (!courses.Any())
            {
                return null;
            }

            return _mapper.Map<List<CourseModel>>(courses);
        }

        public async Task<(List<CourseModel>?, long)> GetAllCourseSearch(CourseModel courseModel, int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var courses = _mapper.Map<Course>(courseModel);
            var coursesWithTotalOrigin = await _repository.GetAllCourseSearch(courses, pageNumber, pageSize, sortField, sortOrder);

            if (!coursesWithTotalOrigin.Item1.Any())
            {
                return (null, coursesWithTotalOrigin.Item2);
            }
            var courseModels = _mapper.Map<List<CourseModel>>(coursesWithTotalOrigin.Item1);

            return (courseModels, coursesWithTotalOrigin.Item2);
        }
    }
}
