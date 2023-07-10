using NTier.Application.Repositories;
using NTier.Domain.Models;
using System.Reflection;

namespace NTier.Application.TodoList;

public class TodoListService : ITodoListService
{
	private readonly ITodoListRepository todoListRepository;

	public TodoListService(ITodoListRepository todoListRepository)
	{
		this.todoListRepository = todoListRepository;
	}
	public Task<List<Domain.Models.TodoList>> GetAllAsync()
	{
		throw new NotImplementedException();
	}
}
