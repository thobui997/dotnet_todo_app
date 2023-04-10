using Microsoft.EntityFrameworkCore;
using ToDoApp.API.Domain.Repositories;
using ToDoApp.API.Domain.Services;
using ToDoApp.API.Mapping;
using ToDoApp.API.Persistence.Contexts;
using ToDoApp.API.Persistence.Repositories;
using ToDoApp.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<SeedData>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase"));
});

builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Console.WriteLine(args[0].ToLower());

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    Console.WriteLine("run");
    SeedData(app);
}

void SeedData(IHost host)
{
    var scopeFactory = host.Services.GetService<IServiceScopeFactory>();
    using var scope = scopeFactory?.CreateScope();
    var service = scope?.ServiceProvider.GetService<SeedData>();
    service?.Seed();
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();