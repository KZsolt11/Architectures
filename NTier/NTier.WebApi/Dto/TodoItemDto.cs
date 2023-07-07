using AutoMapper;
using NTier.Domain.Models;

namespace NTier.WebApi.Dto
{
	public class TodoItemDto
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public int TodoListId { get; set; }
		public string TodoListTitle { get; set; }
	}

	public class TodoItemDtoMapper : Profile
	{
		public TodoItemDtoMapper()
		{
			CreateMap<TodoItem, TodoItemDto>()
				.ForMember(dest => dest.TodoListId, opt => opt.MapFrom(src => src.TodoList.Id))
				.ForMember(dest => dest.TodoListTitle, opt => opt.MapFrom(src => src.TodoList.Title));
		}
	}
}
