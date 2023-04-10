using ToDoApp.API.Domain.Models;

namespace ToDoApp.API.Domain.Repositories;

public interface IToDoRepository
{
    Task<IEnumerable<ToDo>> ListAsync();
    Task AddAsync(ToDo toDo);
}