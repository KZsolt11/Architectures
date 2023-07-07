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
		return todoItemRepository.GetAllAsync(i =>
			i.TodoList.Title.Contains(filter.FreeText) ||
			i.Text.Contains(filter.FreeText));
	}

	List<Domain.Models.TodoItem> ITodoItemService.GetAll(TodoItemFilter filter)
	{
		throw new NotImplementedException();
	}
}