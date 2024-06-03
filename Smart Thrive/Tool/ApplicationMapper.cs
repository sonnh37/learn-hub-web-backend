using AutoMapper;
using SmartThrive.DataAccesss.Model.RequestModel;
using ST.Entities.Data.Table;

namespace Smart_Thrive.Tool
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 
        CreateMap<User, UserRequest>().ReverseMap();
        }
    }
}
