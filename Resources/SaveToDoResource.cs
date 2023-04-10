using System.ComponentModel.DataAnnotations;

namespace ToDoApp.API.Resources;

public class SaveToDoResource
{
    [Required(ErrorMessage = "Tên task là thông tin bắt buộc")] 
    [MaxLength(30)] 
    public string Name { get; set; }

    public string Description { get; set; }
}