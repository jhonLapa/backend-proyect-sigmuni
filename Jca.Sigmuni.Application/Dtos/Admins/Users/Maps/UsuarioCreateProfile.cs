using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Roles;
using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users.Maps
{
    public class UsuarioCreateProfile : Profile
    {
        public UsuarioCreateProfile()
        {
            CreateMap<Usuario, UsuarioCreateDto>().ReverseMap();
        }
    }
}
