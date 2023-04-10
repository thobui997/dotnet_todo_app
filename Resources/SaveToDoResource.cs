using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.Resources;

public class SaveToDoResource
{
    [Required] 
    [MaxLength(30)] 
    public string Name { get; set; }

    public string Description { get; set; }
}