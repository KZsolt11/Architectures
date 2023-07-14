using AutoMapper;
using NTier.Domain.Models;

namespace NTier.Persistence.Repositories;

public class UserMapper : Profile
{
	public UserMapper()
	{
		CreateMap<User, Entities.User>();
		CreateMap<Entities.User, User>();		
	}
}