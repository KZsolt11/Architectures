using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTier.Application.Repositories;
using NTier.Persistence.Context;

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

	public virtual List<TModel> GetAll(Action<IQueryOption<TModel>> queryOptions = null)
	{
		return ApplyQueryOptions(queryOptions)
			.ToList()
			.Select(e => mapper.Map<TModel>(e))
			.ToList();
	}

	public virtual async Task<List<TModel>> GetAllAsync(Action<IQueryOption<TModel>> queryOptions = null)
	{
		var entities = (await ApplyQueryOptions(queryOptions).ToListAsync());
		return entities.Select(e => mapper.Map<TModel>(e))
			.ToList();
	}

	public virtual TModel FirstOrDefault(Action<IQueryOption<TModel>> queryOptions = null)
	{
		var entity = ApplyQueryOptions(queryOptions)
			.FirstOrDefault();
		return mapper.Map<TModel>(entity);
	}

	public virtual async Task<TModel> FirstOrDefaultAsync(Action<IQueryOption<TModel>> queryOptions = null)
	{
		var entity = await ApplyQueryOptions(queryOptions)
			.FirstOrDefaultAsync();
		return mapper.Map<TModel>(entity);
	}
	private IQueryable<TEntity> ApplyQueryOptions(Action<IQueryOption<TModel>> options = null)
	{
		if (options == null)
			return dbSet.AsQueryable();

		var queryOption = new QueryOption<TEntity, TModel>(mapper, dbSet.AsQueryable());
		options(queryOption);

		return queryOption.QueryContainer.Query;
	}
}
