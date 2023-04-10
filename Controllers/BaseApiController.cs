using Microsoft.AspNetCore.Mvc;

namespace ToDoApp.API.Controllers;

[Route("/api/[controller]")]
[Produces("application/json")]
[ApiController]
public class BaseApiController : ControllerBase
{
    
}