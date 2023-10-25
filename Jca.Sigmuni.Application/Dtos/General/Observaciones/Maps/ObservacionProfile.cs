using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Observaciones.Maps
{
    public class ObservacionProfile : Profile
    {
        public ObservacionProfile()
        {
            CreateMap<Observacion, ObservacionDto>();
            CreateMap<Observacion, ObservacionDto>().ReverseMap();

            CreateMap<RequestPagination<Observacion>, RequestPagination<ObservacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<Observacion>, ResponsePagination<ObservacionDto>>();
        }
    }
}
