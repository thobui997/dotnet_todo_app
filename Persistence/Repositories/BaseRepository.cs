using ToDoApp.API.Persistence.Contexts;

namespace ToDoApp.API.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    protected BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}