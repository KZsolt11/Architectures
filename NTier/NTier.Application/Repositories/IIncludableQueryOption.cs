using System.Linq.Expressions;

namespace NTier.Application.Repositories;

public interface IIncludableQueryOption<TEntity, TPreviousProperty>: IQueryOption<TEntity>
{
	IIncludableQueryOption<TEntity, TProperty> ThenInclude<TProperty>(
			Expression<Func<TPreviousProperty, TProperty>> navigationPropertyPath);

	IIncludableQueryOption<TEntity, TProperty> ThenIncludeCollection<TProperty>(
			Expression<Func<TPreviousProperty, ICollection<TProperty>>> navigationPropertyPath);
}