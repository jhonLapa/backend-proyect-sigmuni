using System;
using AutoMapper;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.Admins.Roles.Maps
{
	public class RoleProfile : Profile
	{
		public RoleProfile()
		{
			CreateMap<Role, RoleDto>();
			CreateMap<Role, RoleDto>().ReverseMap();

			CreateMap<RequestPagination<Role>, RequestPagination<RoleDto>>().ReverseMap();
			CreateMap<ResponsePagination<Role>, ResponsePagination<RoleDto>>();
		}
	}
}

