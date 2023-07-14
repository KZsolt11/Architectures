using NTier.Application.Repositories;

namespace NTier.Application.TodoItem;
public class TodoItemService : ITodoItemService
{
	private readonly ITodoItemRepository todoItemRepository;

	public TodoItemService(ITodoItemRepository todoItemRepository)
	{
		this.todoItemRepository = todoItemRepository;
	}

	public Task<List<Domain.Models.TodoItem>> GetAllAsync(TodoItemFilter filter)
	{
		return todoItemRepository
			.GetAllAsync(o => o
				.Include(e => e.TodoList)
				.ThenInclude(e => e.Owner)
				.Where(e => string.IsNullOrEmpty(filter.FreeText) || e.Text.Contains(filter.FreeText)));
	}

	public List<Domain.Models.TodoItem> GetAll(TodoItemFilter filter)
	{
		return todoItemRepository
			.GetAll(o => o
				.Include(e => e.TodoList)
				.Where(e => e.Text.Contains(filter.FreeText))
				.Take(10));
	}
}