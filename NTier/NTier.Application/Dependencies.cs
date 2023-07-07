using Microsoft.Extensions.DependencyInjection;
using NTier.Application.TodoItem;
using NTier.Application.TodoList;

namespace NTier.Application;

public static class Dependencies
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ITodoItemService, TodoItemService>();
        services.AddScoped<ITodoListService, TodoListService>();
        return services;
    }
}