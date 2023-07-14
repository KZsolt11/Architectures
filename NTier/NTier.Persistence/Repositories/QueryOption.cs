using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTier.Application.Repositories;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NTier.Persistence.Repositories;
public class QueryContainer<TEntity>
{
	public QueryContainer(IQueryable<TEntity> query)
	{
		Query = query;
	}

	public IQueryable<TEntity> Query { get; set; }
}
public class QueryOption<TEntity, TModel> : IQueryOption<TModel>
	where TEntity : class
{
	protected string CurrentNavigationPath;
	protected Type CurrentType;

	protected readonly IMapper mapper;
	public QueryContainer<TEntity> QueryContainer { get; set; }
	public QueryOption(IMapper mapper, QueryContainer<TEntity> queryContainer)
	{
		this.mapper = mapper;
		QueryContainer = queryContainer;
	}
	public QueryOption(IMapper mapper, IQueryable<TEntity> query)
	{
		this.mapper = mapper;
		QueryContainer = new QueryContainer<TEntity>(query);
	}

	public IIncludableQueryOption<TModel, TProperty> Include<TProperty>(Expression<Func<TModel, TProperty>> expression)
	{
		(CurrentType, CurrentNavigationPath) = QueryOptionHelper.GetMappedProperty(typeof(TModel), typeof(TEntity), mapper, expression);

		QueryContainer.Query = QueryContainer.Query.Include(CurrentNavigationPath);

		return new IncludableQueryOption<TEntity, TModel, TProperty>(mapper, QueryContainer, CurrentNavigationPath, CurrentType);
	}

	public IIncludableQueryOption<TModel, TProperty> IncludeCollection<TProperty>(Expression<Func<TModel, ICollection<TProperty>>> expression)
	{
		(CurrentType, CurrentNavigationPath) = QueryOptionHelper.GetMappedProperty(typeof(TModel), typeof(TEntity), mapper, expression);

		QueryContainer.Query = QueryContainer.Query.Include(CurrentNavigationPath);

		return new IncludableQueryOption<TEntity, TModel, TProperty>(mapper, QueryContainer, CurrentNavigationPath, CurrentType);
	}

	public IQueryOption<TModel> Where(Expression<Func<TModel, bool>> expression)
	{
		ResetIncludeNavigationPath();
		QueryContainer.Query = QueryContainer.Query.Where(mapper.Map<Expression<Func<TEntity, bool>>>(expression));
		return this;
	}

	public IQueryOption<TModel> Skip(int count)
	{
		ResetIncludeNavigationPath();
		QueryContainer.Query = QueryContainer.Query.Skip(count);
		return this;
	}

	public IQueryOption<TModel> Take(int count)
	{
		ResetIncludeNavigationPath();
		QueryContainer.Query = QueryContainer.Query.Take(count);
		return this;
	}

	private void ResetIncludeNavigationPath()
	{
		CurrentNavigationPath = "";
		CurrentType = null;
	}
}
