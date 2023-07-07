using Microsoft.Extensions.DependencyInjection;
using NTier.Application.Repositories;
using NTier.Persistence.Repositories;
using System.Reflection;

namespace NTier.Persistence;

public static class Dependencies
{
	public static IServiceCollection AddPersistence(this IServiceCollection services)
	{
		services.AddAutoMapper(Assembly.GetExecutingAssembly());
		services.AddScoped<ITodoItemRepository, TodoItemRepository>();

		return services;
	}
}
