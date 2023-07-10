using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NTier.Application.Repositories;
using NTier.Domain.Models;
using NTier.Persistence.Context;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace NTier.Persistence.Repositories;
public class RepositoryBase<TModel, TEntity> : IRepository<TModel>
	where TModel : class
	where TEntity : class
{
	protected readonly DatabaseContext context;
	protected readonly IMapper mapper;
	protected readonly DbSet<TEntity> dbSet;

	public RepositoryBase(DatabaseContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
		dbSet = context.Set<TEntity>();
	}

	public virtual TModel GetById(int id)
	{
		throw new NotImplementedException();
	}

	public virtual Task<TModel> GetByIdAsync(int id)
	{
		throw new NotImplementedException();
	}

	public virtual List<TModel> GetAll<TProperty>(Expression<Func<TModel, bool>> expression = null, params Expression<Func<TModel, TProperty>>[] includes)
	{
		var query = dbSet.AsQueryable();

		if (includes != null)
		{
			foreach (var include in includes)
			{
				query = query.Include(mapper.Map<Expression<Func<TEntity, TProperty>>>(include));
			}
		}

		if (expression != null)
		{
			query = query.Where(mapper.Map<Expression<Func<TEntity, bool>>>(expression));
		}

		return mapper.Map<List<TModel>>(query.ToList());
	}

	public virtual async Task<List<TModel>> GetAllAsync<TProperty>(Expression<Func<TModel, bool>> expression = null, params Expression<Func<TModel, TProperty>>[] includes)
	{
		var query = dbSet.AsQueryable();

		if (includes != null)
		{
			foreach (var include in includes)
			{
				query = query.Include(mapper.Map<Expression<Func<TEntity, TProperty>>>(include));
			}
		}

		if (expression != null)
		{
			query = query.Where(mapper.Map<Expression<Func<TEntity, bool>>>(expression));
		}

		return mapper.Map<List<TModel>>(await query.ToListAsync());
	}

	public virtual TModel Add(TModel model)
	{
		throw new NotImplementedException();
	}

	public virtual Task<TModel> AddAsync(TModel model)
	{
		throw new NotImplementedException();
	}

	public virtual TModel Update(TModel model)
	{
		throw new NotImplementedException();
	}

	public virtual Task<TModel> UpdateAsync(TModel model)
	{
		throw new NotImplementedException();
	}

	public virtual void Remove(TModel model)
	{
		throw new NotImplementedException();
	}

	public virtual Task RemoveAsync(TModel model)
	{
		throw new NotImplementedException();
	}
	public void Test(Action<IQueryOption<TModel>> options = null)
	{
		var queryOption = new QueryOption<TEntity, TModel>(mapper, dbSet.AsQueryable());
		options(queryOption);

		var entities = queryOption.Query.ToList();
		Console.WriteLine(entities.Count);
	}
}

public class QueryOption<TEntity, TModel> : IQueryOption<TModel>
	where TEntity : class
{
	private readonly IMapper mapper;
	public IQueryable<TEntity> Query { get; private set; }
	public QueryOption(IMapper mapper, IQueryable<TEntity> query)
	{
		this.mapper = mapper;
		Query = query;
	}

	public IQueryOption<TModel> Include<TProperty>(Expression<Func<TModel, TProperty>> expression)
		where TProperty : class
	{
		var exp = mapper.Map<Expression<Func<TEntity, object>>>(expression);
		var includeDestType = (exp.Body as UnaryExpression).Operand.Type;

		MethodInfo mapMethod = mapper.GetType().GetMethods().FirstOrDefault(m =>
			m.Name == nameof(mapper.Map) &&
			m.ContainsGenericParameters &&
			m.GetGenericArguments().Count() == 2 &&
			m.GetParameters().Length == 1);

		var destType = typeof(Expression<>).MakeGenericType(Expression.GetFuncType(typeof(TEntity), includeDestType));

		MethodInfo genericMapMethod = mapMethod.MakeGenericMethod(typeof(Expression<Func<TModel, TProperty>>), destType);

		var mappedExpression = genericMapMethod.Invoke(mapper, new object[] { expression });

		var includeMethod = typeof(EntityFrameworkQueryableExtensions).GetMethods()
			.FirstOrDefault(m => m.Name == nameof(EntityFrameworkQueryableExtensions.Include) &&
			m.GetParameters().Count() == 2);

		MethodInfo genericInclude = includeMethod.MakeGenericMethod(typeof(TEntity), includeDestType);

		Query = genericInclude.Invoke(null, new object[] { Query, mappedExpression }) as IQueryable<TEntity>;
		return this;
	}
}