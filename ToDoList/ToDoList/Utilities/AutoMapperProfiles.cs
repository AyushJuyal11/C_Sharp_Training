using AutoMapper;
using ToDoList.DAL.Entities;
using ToDoList.Models.RequestViewModels;
using ToDoList.Models.ResponseViewModels;

namespace ToDoList.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<ToDoRequest, ToDoEntity>();
            CreateMap<ToDoResponse , ToDoEntity>();
            CreateMap<ToDoEntity, ToDoResponse>(); 
        }
    }
}
