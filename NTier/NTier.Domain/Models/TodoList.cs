namespace NTier.Domain.Models;

public class TodoList : IAuditable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public List<TodoItem> TodoItems { get; set; } = new List<TodoItem>();
}