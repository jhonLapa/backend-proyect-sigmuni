using System;
using AutoMapper;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users.Maps
{
	public class UsuarioTokenProfile : Profile
    {
        public UsuarioTokenProfile()
        {
            CreateMap<Usuario, UsuarioTokenDto>();
        }
    }
}

