using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using NTier.Application.Repositories;
using NTier.Domain.Models;
using NTier.Persistence.Context;
using System.Linq;
using System.Linq.Expressions;

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
}