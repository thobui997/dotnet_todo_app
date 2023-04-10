using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Domain.Models;
using ToDoApp.API.Domain.Repositories;
using ToDoApp.API.Persistence.Contexts;

namespace ToDoApp.API.Persistence.Repositories;

public class ToDoRepository : BaseRepository, IToDoRepository
{
    public ToDoRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ToDo>> ListAsync()
    {
        return await _context.ToDoList.AsNoTracking().ToListAsync();
    }

    public async Task AddAsync(ToDo toDo)
    {
        await _context.ToDoList.AddAsync(toDo);
    }
}