using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
    protected readonly DatabaseContext Context;
	private readonly IMapper mapper;
	protected readonly DbSet<TEntity> DbSet;
    public RepositoryBase(DatabaseContext context,IMapper mapper)
    {
        this.Context = context;
		this.mapper = mapper;
		DbSet = context.Set<TEntity>();
    }

    public TModel Add(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task<TModel> AddAsync(TModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TModel model)
    {
        throw new NotImplementedException();
    }

    public List<TModel> GetAll()
    {
        throw new NotImplementedException();
    }

    public List<TModel> GetAll(Expression<Func<TModel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<List<TModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<List<TModel>> GetAllAsync(Expression<Func<TModel, bool>> expression)
    {
        return DbSet.Where(mapper.Map<Expression<Func<TEntity, bool>>>(expression))
            .ProjectTo<TModel>(mapper.ConfigurationProvider)
            .ToListAsync();
	}

    public TModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TModel> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TModel> Query()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TModel> Query(Expression<Func<TModel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TModel>> QueryAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IQueryable<TModel>> QueryAsync(Expression<Func<TModel, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public TModel Update(TModel model)
    {
        throw new NotImplementedException();
    }

    public Task<TModel> UpdateAsync(TModel model)
    {
        throw new NotImplementedException();
    }
}
