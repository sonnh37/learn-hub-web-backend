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
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            _repository = unitOfWork.CategoryRepository;
        }
        public async Task<bool> Add(CategoryModel model)
        {
            try
            {
                var category = _mapper.Map<Category>(model);
                var setCategory = await SetBaseEntityToCreateFunc(category);
                return await _repository.Add(setCategory);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(CategoryModel model)
        {
            try
            {
                return await _repository.Delete(_mapper.Map<Category>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(List<CategoryModel>?, long)> Search(CategoryModel model, int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            var category = _mapper.Map<Category>(model);
            var categoryWithTotalOrigin = await _repository.Search(category, pageNumber, pageSize, sortField, sortOrder);

            if (!categoryWithTotalOrigin.Item1.Any())
            {
                return (null, categoryWithTotalOrigin.Item2);
            }
            var models = _mapper.Map<List<CategoryModel>>(categoryWithTotalOrigin.Item1);

            return (models, categoryWithTotalOrigin.Item2);
        }

        public async Task<bool> Update(CategoryModel model)
        {
            try
            {
                return await _repository.Update(_mapper.Map<Category>(model));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CategoryModel>> GetAllPaginationWithOrder(int pageNumber, int pageSize, string sortField, int sortOrder)
        {
            try
            {
                return _mapper.Map<List<CategoryModel>>(await _repository.GetAllPaginationWithOrder(pageNumber, pageSize, sortField, sortOrder));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CategoryModel> GetById(Guid id)
        {
            try
            {
                var subject = await _repository.GetById(id);
                return _mapper.Map<CategoryModel>(subject);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CategoryModel>> GetAll()
        {
            return _mapper.Map<List<CategoryModel>>(await _repository.GetAll());
        }

    }
}
