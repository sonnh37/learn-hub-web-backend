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
    public class SubjectService : BaseService<Subject>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        public SubjectService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _subjectRepository = unitOfWork.SubjectRepository;
        }
        public async Task<bool> Add(SubjectModel model)
        {
            try
            {
                var subject = _mapper.Map<Subject>(model);
                var setSubject = await SetBaseEntityToCreateFunc(subject);
                return await _subjectRepository.Add(setSubject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(SubjectModel model)
        {
            try
            {
                return await _subjectRepository.Delete(_mapper.Map<Subject>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(List<SubjectModel>?, long)> Search(SubjectModel model, int pageNumber, int pageSize, string orderBy)
        {
            var subject = _mapper.Map<Subject>(model);
            var subjectWithTotalOrigin = await _subjectRepository.Search(subject, pageNumber, pageSize, orderBy);

            if (!subjectWithTotalOrigin.Item1.Any())
            {
                return (null, subjectWithTotalOrigin.Item2);
            }
            var models = _mapper.Map<List<SubjectModel>>(subjectWithTotalOrigin.Item1);

            return (models, subjectWithTotalOrigin.Item2);
        }

        public async Task<bool> Update(SubjectModel model)
        {
            try
            {
                return await _subjectRepository.Update(_mapper.Map<Subject>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SubjectModel>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string orderBy)
        {
            try
            {
                return _mapper.Map<List<SubjectModel>>(await _subjectRepository.GetAllPaginationWithOrder(pageNumber, pageSize, orderBy));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<SubjectModel> GetById(Guid id)
        {
            try
            {
                var subject = await _subjectRepository.GetById(id);
                return _mapper.Map<SubjectModel>(subject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SubjectModel>> GetByCategoryId(Guid id)
        {
            try
            {
                var subjects = await _subjectRepository.GetByCategoryId(id);
                return _mapper.Map<List<SubjectModel>>(subjects);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SubjectModel>> GetAll()
        {
            return _mapper.Map<List<SubjectModel>>(await _subjectRepository.GetAll());
        }
    }
}
