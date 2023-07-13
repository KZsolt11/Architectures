using NTier.Domain.Models;

namespace NTier.Application.Repositories;

public interface IRepository<TModel> where TModel : class
{
	public TModel GetById(int id);
	public Task<TModel> GetByIdAsync(int id);
	public List<TModel> GetAll(Action<IQueryOption<TModel>> queryOptions = null);
	public Task<List<TModel>> GetAllAsync(Action<IQueryOption<TModel>> queryOptions = null);
	public TModel FirstOrDefault(Action<IQueryOption<TModel>> queryOptions = null);
	public Task<TModel> FirstOrDefaultAsync(Action<IQueryOption<TModel>> queryOptions = null);
	public TModel Add(TModel model);
	public Task<TModel> AddAsync(TModel model);
	public TModel Update(TModel model);
	public Task<TModel> UpdateAsync(TModel model);
	public void Remove(TModel model);
	public Task RemoveAsync(TModel model);
}