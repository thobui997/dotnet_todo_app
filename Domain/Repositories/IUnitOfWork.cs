namespace ToDoApp.API.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}