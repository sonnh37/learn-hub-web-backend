using AutoMapper;
using Smart_Thrive.RequestModel;
using SmartThrive.DataAccesss.Model;
using SmartThrive.DataAccesss.Model.RequestModel;
using ST.Entities.Data.Table;
using ST.Entities.Model;
using SWD.DataAccesss.Model;

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
            CreateMap<Course, CourseModel>().ReverseMap();
            CreateMap<Package, PackageModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
               
            CreateMap<UserModel ,UserRequest>().ReverseMap();
            CreateMap<CategoryModel, CategoryRequest>().ReverseMap();
            CreateMap<ProviderModel, ProviderRequest>().ReverseMap();
            CreateMap<SubjectModel, SubjectRequest>().ReverseMap();
            CreateMap<SessionModel, SessionRequest>().ReverseMap();
            CreateMap<StudentModel, StudentRequest>().ReverseMap();
            CreateMap<CourseModel, CourseRequest>().ReverseMap();
            CreateMap<PackageModel, PackageRequest>().ReverseMap();
            CreateMap<OrderModel, OrderRequest>().ReverseMap();
           
        }
    }
}
