﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NTier.Application.Repositories;
using System.Linq.Expressions;

namespace NTier.Persistence.Repositories;

public class IncludableQueryOption<TEntity, TModel, TIncluded> : QueryOption<TEntity, TModel>, IIncludableQueryOption<TModel, TIncluded>
	where TEntity : class
{
	public IncludableQueryOption(IMapper mapper, QueryContainer<TEntity> queryContainer, string currentNavigationPath, Type currentType) : base(mapper, queryContainer)
	{
		CurrentNavigationPath = currentNavigationPath;
		CurrentType = currentType;
	}

	public IncludableQueryOption(IMapper mapper, IQueryable<TEntity> query) : base(mapper, query)
	{
	}

	public IIncludableQueryOption<TModel, TProperty> ThenInclude<TProperty>(Expression<Func<TIncluded, TProperty>> navigationPropertyPath)
	{
		var (type, name) = QueryOptionHelper.GetMappedProperty(typeof(TIncluded), CurrentType, mapper, navigationPropertyPath);
		CurrentType = type;
		CurrentNavigationPath = $"{CurrentNavigationPath}.{name}";

		QueryContainer.Query = QueryContainer.Query.Include(CurrentNavigationPath);

		return new IncludableQueryOption<TEntity, TModel, TProperty>(mapper, QueryContainer, CurrentNavigationPath, CurrentType);
	}

	public IIncludableQueryOption<TModel, TProperty> ThenIncludeCollection<TProperty>(Expression<Func<TIncluded, ICollection<TProperty>>> navigationPropertyPath)
	{
		throw new NotImplementedException();
	}
}
