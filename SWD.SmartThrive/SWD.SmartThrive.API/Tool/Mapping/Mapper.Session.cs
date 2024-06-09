using AutoMapper;
using SWD.SmartThrive.API.RequestModel;
using SWD.SmartThrive.Repositories.Data.Table;
using SWD.SmartThrive.Services.Model;

namespace SWD.SmartThrive.API.Tool.Mapping
{
    public partial class Mapper : Profile
    {
        public void SessionMapping()
        {
            CreateMap<Session, SessionModel>().ReverseMap();
            CreateMap<SessionModel, SessionRequest>().ReverseMap();
        }
    }
}
