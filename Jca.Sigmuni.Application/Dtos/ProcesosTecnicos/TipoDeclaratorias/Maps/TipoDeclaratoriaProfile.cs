using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias.Maps
{
    public class TipoDeclaratoriaProfile : Profile
    {
        public TipoDeclaratoriaProfile()
        {
            CreateMap<TipoDeclaratoria, TipoDeclaratoriaDto>();
            CreateMap<TipoDeclaratoria, TipoDeclaratoriaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDeclaratoria>, RequestPagination<TipoDeclaratoriaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDeclaratoria>, ResponsePagination<TipoDeclaratoriaDto>>();
        }
    }
}
