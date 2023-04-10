using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ToDoApp.API.Extensions;

public static class ModelStateExtension
{
    public static List<string> GetErrorMessage(this ModelStateDictionary stateDictionary)
    {
        return stateDictionary.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage).ToList();
    }
}