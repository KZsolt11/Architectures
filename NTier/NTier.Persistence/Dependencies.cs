using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NTier.Application.Repositories;
using NTier.Persistence.Context;
using NTier.Persistence.Repositories;
using System.Reflection;

namespace NTier.Persistence;

public static class Dependencies
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAutoMapper(cfg => 
		{
			cfg.AddExpressionMapping();
		}
		,Assembly.GetExecutingAssembly());

		services.AddDbContext<DatabaseContext>(o =>
		{
			o.UseSqlServer(configuration.GetConnectionString("Default"));
		});

		services.AddScoped<ITodoItemRepository, TodoItemRepository>();
		services.AddScoped<ITodoListRepository, TodoListRepository>();

		return services;
	}
}
