using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NTier.Application.TodoItem;
using NTier.Application.TodoList;
using NTier.WebApi.Dto;

namespace NTier.WebApi.Controllers;


[Route("todo-items")]
public class TodoItemController : ControllerBase
{
	private readonly ITodoItemService todoItemService;
	private readonly IMapper mapper;

	public TodoItemController(ITodoItemService todoItemService, IMapper mapper)
	{
		this.todoItemService = todoItemService;
		this.mapper = mapper;
	}

	[HttpGet]
	public async Task<ActionResult<List<TodoItemDto>>> GetAll(TodoItemFilter filter)
	{
		var items = await todoItemService
			.GetAllAsync(filter);

		return Ok(mapper.Map<List<TodoItemDto>>(items));
	}
}