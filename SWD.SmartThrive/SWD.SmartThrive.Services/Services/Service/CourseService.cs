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

        public async Task<bool> AddCourse(CourseModel CourseModel)
        {
            var Course = _mapper.Map<Course>(CourseModel);
            return await _repository.Add(Course);
        }

        public async Task<bool> UpdateCourse(CourseModel CourseModel)
        {
            var entity = await _repository.GetById(CourseModel.Id);
            if (entity == null)
            {
                return false;
            }

            var Course = _mapper.Map<Course>(CourseModel);
            return await _repository.Update(Course);
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

            if (Courses == null)
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

        
    }
}
