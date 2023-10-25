using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones.Maps
{
    public class IntervencionConservacionProfile : Profile
    {
        public IntervencionConservacionProfile()
        {
            CreateMap<IntervencionConservacion, IntervencionConservacionDto>();
            CreateMap<IntervencionConservacion, IntervencionConservacionDto>().ReverseMap();

            CreateMap<RequestPagination<IntervencionConservacion>, RequestPagination<IntervencionConservacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<IntervencionConservacion>, ResponsePagination<IntervencionConservacionDto>>();
        }
    }
}
