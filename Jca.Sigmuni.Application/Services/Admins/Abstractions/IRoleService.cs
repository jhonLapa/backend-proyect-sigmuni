using System;
using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.Roles;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
	public interface IRoleService : IServiceCrud <RoleDto, RoleFormDto, int >, IServicePaginated<RoleDto>
	{
	}
}

