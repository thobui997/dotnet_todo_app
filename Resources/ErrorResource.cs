namespace ToDoApp.API.Resources;

public class ErrorResource
{
    public bool Success => false;
    public List<string> Messages { get; private set; }

    public ErrorResource(List<string> message)
    {
        Messages = message ?? new List<string>();
    }
    
    public ErrorResource(string message)
    {
        Messages = new List<string>();

        if(!string.IsNullOrWhiteSpace(message))
        {
            Messages.Add(message);
        }
    }
}