using AutoMapper;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.Repositories.Data.Entities;
using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.API.Tool.Mapping
{
    public partial class Mapper : Profile
    {
        public void SubjectMapping()
        {
            CreateMap<Subject, SubjectModel>().ReverseMap();
            CreateMap<SubjectModel, SubjectRequest>().ReverseMap();
        }
    }
}
