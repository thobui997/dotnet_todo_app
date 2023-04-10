using AutoMapper;
using ToDoApp.API.Domain.Models;
using ToDoApp.API.Resources;

namespace ToDoApp.API.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ToDo, ToDoResource>();
    }
    
}