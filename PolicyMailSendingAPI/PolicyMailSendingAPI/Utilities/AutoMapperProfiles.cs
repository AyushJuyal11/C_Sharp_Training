using AutoMapper;
using PolicyMailSendingAPI.DAL.Entities;
using PolicyMailSendingAPI.Models.RequestViewModels;

namespace PolicyMailSendingAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRequestModel, UserEntity>();
            CreateMap<UserEntity, UserRequestModel>(); 
        }
    }
}
