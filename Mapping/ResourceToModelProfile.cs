using AutoMapper;
using ToDoApp.API.Domain.Models;
using ToDoApp.API.Resources;

namespace ToDoApp.API.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveToDoResource, ToDo>();
    }
}