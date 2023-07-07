using AutoMapper;
using NTier.Domain.Models;

namespace NTier.Persistence.Repositories;

public class TodoItemMapper : Profile
{
	public TodoItemMapper()
	{
		CreateMap<TodoItem, Entities.TodoItem>();
		CreateMap<Entities.TodoItem, TodoItem>();
	}
}