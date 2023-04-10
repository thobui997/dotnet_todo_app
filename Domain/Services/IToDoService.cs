using ToDoApp.API.Domain.Models;
using ToDoApp.API.Domain.Services.Communications;

namespace ToDoApp.API.Domain.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDo>> ListAsync();
    Task<ToDoResponse> SaveAsync(ToDo todo);
    Task<ToDoResponse> UpdateAsync(string id, ToDo todo);
}