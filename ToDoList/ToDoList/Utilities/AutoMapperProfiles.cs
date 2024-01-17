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
            CreateMap<ToDoItemRequest, ToDoItem>();
            CreateMap<ToDoItemResponse , ToDoItem>();
            CreateMap<ToDoItem, ToDoItemResponse>(); 
        }
    }
}
