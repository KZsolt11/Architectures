using NTier.Domain.Models;
using System.Linq.Expressions;

namespace NTier.Application.Repositories;

public interface IRepository<TModel> where TModel : class
{
	public TModel GetById(int id);
	public IQueryable<TModel> Query();
	public IQueryable<TModel> Query(Expression<Func<TModel, bool>> expression);	
	public List<TModel> GetAll();
	public List<TModel> GetAll(Expression<Func<TModel, bool>> expression);
	public TModel Add(TModel model);
	public TModel Update(TModel model);
	public void Delete(TModel model);

	public Task<TModel> GetByIdAsync(int id);
	public Task<List<TModel>> GetAllAsync();
	public Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>> expression);
	public Task<TModel> AddAsync(TModel model);
	public Task<TModel> UpdateAsync(TModel model);
	public Task DeleteAsync(TModel model);
}