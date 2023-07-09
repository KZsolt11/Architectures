using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NTier.Application.Repositories;
using NTier.Domain.Models;
using NTier.Persistence.Context;
using System.Linq;
using System.Linq.Expressions;

namespace NTier.Persistence.Repositories;

public class TodoItemRepository : RepositoryBase<TodoItem, Entities.TodoItem>, ITodoItemRepository
{
	public TodoItemRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
	{
	}
}