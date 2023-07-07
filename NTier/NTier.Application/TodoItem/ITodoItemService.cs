namespace NTier.Application.TodoItem
{
	public interface ITodoItemService
	{
		List<Domain.Models.TodoItem> GetAll(TodoItemFilter filter);
		Task<List<Domain.Models.TodoItem>> GetAllAsync(TodoItemFilter filter);
	}
}