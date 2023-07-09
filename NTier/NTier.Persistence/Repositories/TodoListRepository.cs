using AutoMapper;
using NTier.Application.Repositories;
using NTier.Domain.Models;
using NTier.Persistence.Context;

namespace NTier.Persistence.Repositories;

public class TodoListRepository : RepositoryBase<TodoList, Entities.TodoList>, ITodoListRepository
{
	public TodoListRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
	{
	}
}