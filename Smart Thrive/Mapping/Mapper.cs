using AutoMapper;
using SmartThrive.DataAccesss.Model;
using ST.Entities.Data.Table;
using ST.Entities.Model;

namespace Smart_Thrive.Mapping
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Provider, ProviderModel>().ReverseMap();
            CreateMap<Subject, SubjectModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Session, SessionModel>().ReverseMap();
            CreateMap<Student, StudentModel>().ReverseMap();

        }
    }
}
