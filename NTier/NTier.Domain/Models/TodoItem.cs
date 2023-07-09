namespace NTier.Domain.Models;

public class TodoItem : IAuditable
{
    public int Id { get; set; }
    public string Text { get; set; }
    public int TodoListId { get; set; }
    public TodoList TodoList { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
}
