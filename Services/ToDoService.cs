using ToDoApp.API.Domain.Models;
using ToDoApp.API.Domain.Repositories;
using ToDoApp.API.Domain.Services;
using ToDoApp.API.Domain.Services.Communications;

namespace ToDoApp.API.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _toDoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ToDoService(IToDoRepository toDoRepository, IUnitOfWork unitOfWork)
    {
        _toDoRepository = toDoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ToDo>> ListAsync()
    {
        var tasksList = await _toDoRepository.ListAsync();
        return tasksList;
    }

    public async Task<ToDoResponse> SaveAsync(ToDo todo)
    {
        try
        {
            await _toDoRepository.AddAsync(todo);
            await _unitOfWork.CompleteAsync();

            return new ToDoResponse(todo);
        }
        catch (Exception ex)
        {
            return new ToDoResponse($"An error occurred when saving the category: {ex.Message}");
        }
    }

    public async Task<ToDoResponse> UpdateAsync(string id, ToDo todo)
    {
        var existingTodo = await _toDoRepository.FindByIdAsync(id);

        if (existingTodo == null)
        {
            return new ToDoResponse("Todo not found!");
        }

        existingTodo.Name = todo.Name;
        existingTodo.Description = todo.Description;

        try
        {
            _toDoRepository.Update(existingTodo);
            await _unitOfWork.CompleteAsync();

            return new ToDoResponse(existingTodo);
        }
        catch (Exception ex)
        {
            // Do some logging stuff
            return new ToDoResponse($"An error occurred when updating the category: {ex.Message}");
        }
    }
}