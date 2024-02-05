using AutoMapper;
using NotificationAPI.DAL.Entities;
using NotificationAPI.Models.RequestViewModels;

namespace NotificationAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRequestModel, User>();
            CreateMap<User, UserRequestModel>(); 
        }
    }
}
