using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TurnoInspeccions.Maps
{
    public class TurnoInspeccionProfile : Profile
    {
        public TurnoInspeccionProfile()
        {
            CreateMap<TurnoInspeccion, TurnoInspeccionDto>();
            CreateMap<TurnoInspeccion, TurnoInspeccionDto>().ReverseMap();

            CreateMap<RequestPagination<TurnoInspeccion>, RequestPagination<TurnoInspeccionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TurnoInspeccion>, ResponsePagination<TurnoInspeccionDto>>();
        }
    }
}
