using AutoMapper;
using NTier.Application.Repositories;
using NTier.Domain.Models;
using NTier.Persistence.Context;

namespace NTier.Persistence.Repositories;

public class TodoItemRepository : RepositoryBase<TodoItem, Entities.TodoItem>, ITodoItemRepository
{
	public TodoItemRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
	{
	}

	public List<TodoItem> GetByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public Task<List<TodoItem>> GetByTitleAsync(string title)
    {
        throw new NotImplementedException();
    }
}
