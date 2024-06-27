using AutoMapper;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.API.Tool.Mapping
{
    public partial class Mapper : Profile
    {
        public void CategoryMapping()
        {
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<CategoryModel, CategoryRequest>().ReverseMap();
            CreateMap<CategoryModel, CategorySearchRequest>().ReverseMap();

        }
    }
}
