using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Monedas.Maps
{
    public class MonedaProfile : Profile
    {
        public MonedaProfile()
        {
            CreateMap<Moneda, MonedaDto>();
            CreateMap<Moneda, MonedaDto>().ReverseMap();

            CreateMap<RequestPagination<Moneda>, RequestPagination<MonedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Moneda>, ResponsePagination<MonedaDto>>();
        }
    }
}
