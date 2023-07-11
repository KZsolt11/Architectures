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
	public void Test(Action<IQueryOption<TModel>> options);
}

//public interface IQueryOption<TModel>
//{
//	IIncludable<TModel, TProperty> Include<TProperty>(Expression<Func<TModel, TProperty>> expression) 
//		where TProperty: class;
//}

//public interface IIncludable<TModel, TIncluded> : IQueryOption<TModel>
//{
//	IIncludable<TModel, TProperty> ThenInclude<TProperty>(Expression<Func<TIncluded, TProperty>> expression);
//}

public interface IQueryOption<TEntity>
{
	IIncludableQueryOption<TEntity, TProperty> Include<TProperty>(
		Expression<Func<TEntity, TProperty>> navigationPropertyPath);
	IIncludableQueryOption<TEntity, TProperty> IncludeCollection<TProperty>(
		Expression<Func<TEntity, ICollection<TProperty>>> navigationPropertyPath);
}

public interface IIncludableQueryOption<TEntity, TPreviousProperty>: IQueryOption<TEntity>
{
	IIncludableQueryOption<TEntity, TProperty> ThenInclude<TProperty>(
			Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath);

	IIncludableQueryOption<TEntity, TProperty> ThenIncludeCollection<TProperty>(
			Expression<Func<TPreviousProperty, ICollection<TProperty>>> navigationPropertyPath);
}