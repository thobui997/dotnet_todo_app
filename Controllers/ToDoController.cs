using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.API.Domain.Models;
using ToDoApp.API.Domain.Services;
using ToDoApp.API.Resources;

namespace ToDoApp.API.Controllers;

public class ToDoController : BaseApiController
{
    private readonly IToDoService _toDoService;
    private readonly IMapper _mapper;

    public ToDoController(IToDoService toDoService, IMapper mapper)
    {
        _toDoService = toDoService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ToDoResource>), 200)]
    public async Task<IEnumerable<ToDoResource>> ListAsync()
    {
        var todoList = await _toDoService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ToDo>, IEnumerable<ToDoResource>>(todoList);

        return resources;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ToDoResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PostAsync([FromBody] SaveToDoResource saveToDoResource)
    {
        var todo = _mapper.Map<SaveToDoResource, ToDo>(saveToDoResource);
        var result = await _toDoService.SaveAsync(todo);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var todoResource = _mapper.Map<ToDo, ToDoResource>(result.Resource);

        return Ok(todoResource);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ToDoResource), 200)]
    [ProducesResponseType(typeof(ErrorResource), 400)]
    public async Task<IActionResult> PutAsync(string id, [FromBody] SaveToDoResource saveToDoResource)
    {
        var todo = _mapper.Map<SaveToDoResource, ToDo>(saveToDoResource);
        var result = await _toDoService.UpdateAsync(id, todo);

        if (!result.Success)
        {
            return BadRequest(new ErrorResource(result.Message));
        }

        var todoResource = _mapper.Map<ToDo, ToDoResource>(result.Resource);

        return Ok(todoResource);
    }
}