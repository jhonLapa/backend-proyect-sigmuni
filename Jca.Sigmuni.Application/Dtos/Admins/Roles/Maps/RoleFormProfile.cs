using System;
using AutoMapper;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Roles.Maps
{
	public class RoleFormProfile : Profile
	{
		public RoleFormProfile()
		{
			CreateMap<Role, RoleFormDto>().ReverseMap();
		}
	}
}

