using System;
using AutoMapper;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users.Maps
{
	public class UsuarioEditProfile: Profile
	{
		public UsuarioEditProfile()
		{
            CreateMap<Usuario, UsuarioEditDto>().ReverseMap();
        }
    }
}

