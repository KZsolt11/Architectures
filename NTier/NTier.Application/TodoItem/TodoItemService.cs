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
			.GetAllAsync(i =>
				string.IsNullOrEmpty(filter.FreeText) ||
				i.TodoList.Title.Contains(filter.FreeText) ||
				i.Text.Contains(filter.FreeText),
			i => i.TodoList);
	}

	public List<Domain.Models.TodoItem> GetAll(TodoItemFilter filter)
	{
		return todoItemRepository.GetAll(i =>
			string.IsNullOrEmpty(filter.FreeText) ||
			i.TodoList.Title.Contains(filter.FreeText) ||
			i.Text.Contains(filter.FreeText),
			i => i.TodoList);
	}
}