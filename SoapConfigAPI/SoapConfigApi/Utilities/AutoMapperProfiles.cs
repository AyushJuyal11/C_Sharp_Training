using AutoMapper;
using SoapConfigAPI.DAL.Entities;
using SoapConfigAPI.Models.RequestViewModels;
using SoapConfigAPI.Models.ResponseViewModels;

namespace SoapConfigAPI.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<SoapConfigRequest, SoapConfigResponse>();
            CreateMap<SoapConfigResponse, SoapConfig>();
            CreateMap<SoapConfigRequest, SoapConfig>();
            CreateMap<SoapConfig, SoapConfigRequest>(); 
        }
    }
}
