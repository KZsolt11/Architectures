namespace NTier.Domain.Models;

public partial class User: IAuditable
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Email { get; set; }
	public DateTime CreatedDate { get; set; }
	public string CreatedBy { get; set; }
	public DateTime? ModifiedDate { get; set; }
	public string ModifiedBy { get; set; }
	public List<TodoList> TodoLists { get; set; } = new List<TodoList>();
}