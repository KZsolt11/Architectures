using AutoMapper;
using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;

namespace NTier.Persistence.Repositories;

public static class QueryOptionHelper
{
	public static (Type, string) GetMappedProperty(Type src, Type dest, IMapper mapper, LambdaExpression expression)
	{
		var includePropertyInfo = GetPropertyInfo(src, expression);
		return GetDestProperty(src, dest, includePropertyInfo, mapper);
	}

	public static (Type, string) GetDestProperty(Type src, Type dest, PropertyInfo propertyInfo, IMapper mapper)
	{
		var map = mapper.ConfigurationProvider.Internal().FindTypeMapFor(src, dest);
		var propertyMap = map.PropertyMaps.FirstOrDefault(pm => pm.SourceType == propertyInfo.PropertyType && pm.SourceMember.Name == propertyInfo.Name);
		if (propertyMap == null)
			throw new ArgumentException($"No property mapping for: {propertyInfo.Name} {propertyInfo.DeclaringType}");
		return (propertyMap.DestinationType, propertyMap.DestinationName);
	}

	public static PropertyInfo GetPropertyInfo(Type source, LambdaExpression propertyLambda)
	{
		if (propertyLambda.Body is not MemberExpression member)
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a method, not a property.",
				propertyLambda.ToString()));
		}

		if (member.Member is not PropertyInfo propInfo)
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a field, not a property.",
				propertyLambda.ToString()));
		}

		if (propInfo.ReflectedType != null && source != propInfo.ReflectedType && !source.IsSubclassOf(propInfo.ReflectedType))
		{
			throw new ArgumentException(string.Format(
				"Expression '{0}' refers to a property that is not from type {1}.",
				propertyLambda.ToString(),
				source));
		}

		return propInfo;
	}
}