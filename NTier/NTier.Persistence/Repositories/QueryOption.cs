using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTier.Application.Repositories;
using System.Linq.Expressions;

namespace NTier.Persistence.Repositories;

public class QueryOption<TEntity, TModel> : IQueryOption<TModel>
	where TEntity : class
{
	protected string CurrentNavigationPath;
	protected Type CurrentType;

	protected readonly IMapper mapper;
	public IQueryable<TEntity> Query { get; protected set; }
	public QueryOption(IMapper mapper, IQueryable<TEntity> query)
	{
		this.mapper = mapper;
		Query = query;
	}

	public IIncludableQueryOption<TModel, TProperty> Include<TProperty>(Expression<Func<TModel, TProperty>> expression)
	{
		(CurrentType, CurrentNavigationPath) = QueryOptionHelper.GetMappedProperty(typeof(TModel), typeof(TEntity), mapper, expression);
		
		Query = Query.Include(CurrentNavigationPath);

		return new IncludableQueryOption<TEntity, TModel, TProperty>(mapper, Query, CurrentNavigationPath, CurrentType);
	}

	public IIncludableQueryOption<TModel, TProperty> IncludeCollection<TProperty>(Expression<Func<TModel, ICollection<TProperty>>> expression)
	{
		(CurrentType, CurrentNavigationPath) = QueryOptionHelper.GetMappedProperty(typeof(TModel), typeof(TEntity), mapper, expression);

		Query = Query.Include(CurrentNavigationPath);

		return new IncludableQueryOption<TEntity, TModel, TProperty>(mapper, Query, CurrentNavigationPath, CurrentType);
	}
	
	public IQueryOption<TModel> Where(Expression<Func<TModel, bool>> expression)
	{
		ResetIncludeNavigationPath();
		Query = Query.Where(mapper.Map<Expression<Func<TEntity, bool>>>(expression));
		return this;
	}

	public IQueryOption<TModel> Skip(int count)
	{
		ResetIncludeNavigationPath();
		Query = Query.Skip(count);
		return this;
	}

	public IQueryOption<TModel> Take(int count)
	{
		ResetIncludeNavigationPath();
		Query = Query.Take(count);
		return this;
	}

	private void ResetIncludeNavigationPath()
	{
		CurrentNavigationPath = "";
		CurrentType = null;
	}
}
