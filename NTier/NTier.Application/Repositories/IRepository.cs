using NTier.Domain.Models;
using System.Linq.Expressions;

namespace NTier.Application.Repositories;

public interface IRepository<TModel> where TModel : class
{
	public TModel GetById(int id);
	public Task<TModel> GetByIdAsync(int id);
	public List<TModel> GetAll<TProperty>(Expression<Func<TModel, bool>> expression = null, params Expression<Func<TModel, TProperty>>[] includes);
	public Task<List<TModel>> GetAllAsync<TProperty>(Expression<Func<TModel, bool>> expression = null, params Expression<Func<TModel, TProperty>>[] includes);
	public TModel Add(TModel model);
	public Task<TModel> AddAsync(TModel model);
	public TModel Update(TModel model);
	public Task<TModel> UpdateAsync(TModel model);
	public void Remove(TModel model);
	public Task RemoveAsync(TModel model);
}