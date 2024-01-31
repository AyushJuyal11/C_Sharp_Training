using AutoMapper;
using PopulateHtmlDataApi.DAL.Entities;
using PopulateHtmlDataApi.Models.RequestViewModels;
using PopulateHtmlDataApi.Models.ResponseViewModels;

namespace PopulateHtmlDataApi.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<HtmlTemplateResponseModel, HtmlTemplateEntity>();
            CreateMap<HtmlTemplateEntity, HtmlTemplateResponseModel>(); 
            CreateMap<HtmlTemplateEntity , HtmlTemplateEntity>();
            CreateMap<UserRequestModel , UserEntity>();
            CreateMap<UserResponseModel , UserEntity>();
            CreateMap<UserEntity, UserResponseModel>();
            CreateMap<UserRequestModel, UserEntity>(); 
            
        }
    }
}
