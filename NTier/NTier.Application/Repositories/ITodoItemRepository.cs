using NTier.Domain.Models;

namespace NTier.Application.Repositories;

public interface ITodoItemRepository : IRepository<Domain.Models.TodoItem>
{
	List<Domain.Models.TodoItem> GetByTitle(string title);
	Task<List<Domain.Models.TodoItem>> GetByTitleAsync(string title);
}