using ToDoApp.API.Domain.Models;

namespace ToDoApp.API.Persistence.Contexts;

public class SeedData
{
    private readonly AppDbContext _context;

    public SeedData(AppDbContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        _context.Database.EnsureCreated();
        if (!_context.ToDoList.Any())
        {
            var todoList = new List<ToDo>()
            {
                new ToDo()
                {
                    Name = "Task 1",
                    Description =
                        "Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)"
                },
                new ToDo()
                {
                    Name = "Task 2",
                    Description =
                        "Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)"
                }
            };
            
            _context.ToDoList.AddRange(todoList);
        }


        _context.SaveChanges();
    }
}