using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios.Maps
{
    public class TipoAnuncioProfile : Profile
    {
        public TipoAnuncioProfile()
        {
            CreateMap<TipoAnuncio, TipoAnuncioDto>();
            CreateMap<TipoAnuncio, TipoAnuncioDto>().ReverseMap();

            CreateMap<RequestPagination<TipoAnuncio>, RequestPagination<TipoAnuncioDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoAnuncio>, ResponsePagination<TipoAnuncioDto>>();
        }
    }
}
