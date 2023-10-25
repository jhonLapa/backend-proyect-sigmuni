using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales.Maps
{
    public class UnidadCatastralProfile : Profile
    {
        public UnidadCatastralProfile()
        {
            CreateMap<UnidadCatastral, UnidadCatastralDto>();
            CreateMap<UnidadCatastral, UnidadCatastralDto>().ReverseMap();

            CreateMap<RequestPagination<UnidadCatastral>, RequestPagination<UnidadCatastralDto>>().ReverseMap();
            CreateMap<ResponsePagination<UnidadCatastral>, ResponsePagination<UnidadCatastralDto>>();
        }
    }
}
