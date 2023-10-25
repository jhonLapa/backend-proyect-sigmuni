using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios.Maps
{
    public class AutorizacionAnuncioProfile : Profile
    {
        public AutorizacionAnuncioProfile()
        {
            CreateMap<AutorizacionAnuncio, AutorizacionAnuncioDto>();
            CreateMap<AutorizacionAnuncio, AutorizacionAnuncioDto>().ReverseMap();

            CreateMap<RequestPagination<AutorizacionAnuncio>, RequestPagination<AutorizacionAnuncioDto>>().ReverseMap();
            CreateMap<ResponsePagination<AutorizacionAnuncio>, ResponsePagination<AutorizacionAnuncioDto>>();
        }
    }
}
