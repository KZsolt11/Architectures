namespace NTier.Application.TodoList
{
	public interface ITodoListService
	{
		Task<List<Domain.Models.TodoList>> GetAllAsync();
	}
}