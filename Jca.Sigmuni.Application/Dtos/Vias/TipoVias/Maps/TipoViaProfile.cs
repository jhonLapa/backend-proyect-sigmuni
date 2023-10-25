using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Application.Dtos.Vias.TipoVias.Maps
{
    public class TipoViaProfile : Profile
    {
        public TipoViaProfile()
        {
            CreateMap<TipoVia, TipoViaDto>();
            CreateMap<TipoVia, TipoViaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoVia>, RequestPagination<TipoViaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoVia>, ResponsePagination<TipoViaDto>>();
        }
    }
}
