using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores.Maps
{
    public class TipoInteriorProfile : Profile
    {
        public TipoInteriorProfile()
        {
            CreateMap<TipoInterior, TipoInteriorDto>();
            CreateMap<TipoInterior, TipoInteriorDto>().ReverseMap();

            CreateMap<RequestPagination<TipoInterior>, RequestPagination<TipoInteriorDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoInterior>, ResponsePagination<TipoInteriorDto>>();
        }
    }
}
