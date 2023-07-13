using System.Linq.Expressions;

namespace NTier.Application.Repositories;

public interface IQueryOption<TEntity>
{
	IIncludableQueryOption<TEntity, TProperty> Include<TProperty>(
		Expression<Func<TEntity, TProperty>> navigationPropertyPath);
	IIncludableQueryOption<TEntity, TProperty> IncludeCollection<TProperty>(
		Expression<Func<TEntity, ICollection<TProperty>>> navigationPropertyPath);

	IQueryOption<TEntity> Where(Expression<Func<TEntity, bool>> expression);
	IQueryOption<TEntity> Skip(int skip);
	IQueryOption<TEntity> Take(int take);
}
