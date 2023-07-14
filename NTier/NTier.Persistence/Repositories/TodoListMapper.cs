using AutoMapper;
using NTier.Domain.Models;

namespace NTier.Persistence.Repositories;

public class TodoListMapper : Profile
{
	public TodoListMapper()
	{
		CreateMap<TodoList, Entities.TodoList>();
		CreateMap<Entities.TodoList, TodoList>();		
	}
}
