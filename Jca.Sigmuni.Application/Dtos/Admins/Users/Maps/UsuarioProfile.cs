using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users.Maps
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioDto>();
            CreateMap<Usuario, UsuarioDto>().ReverseMap();

            CreateMap<RequestPagination<Usuario>, RequestPagination<UsuarioDto>>().ReverseMap();
            CreateMap<ResponsePagination<Usuario>, ResponsePagination<UsuarioDto>>();
        }
    }
}
