using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Perfiles.Maps
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<Perfil, PerfilDto>();
            CreateMap<Perfil, PerfilDto>().ReverseMap();

            CreateMap<RequestPagination<Perfil>, RequestPagination<PerfilDto>>().ReverseMap();
            CreateMap<ResponsePagination<Perfil>, ResponsePagination<PerfilDto>>();
        }
    }
}