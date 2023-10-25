using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocNotariales.Maps
{
    public class TipoDocNotarialProfile : Profile
    {
        public TipoDocNotarialProfile()
        {
            CreateMap<TipoDocNotarial, TipoDocNotarialDto>();
            CreateMap<TipoDocNotarial, TipoDocNotarialDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDocNotarial>, RequestPagination<TipoDocNotarialDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDocNotarial>, ResponsePagination<TipoDocNotarialDto>>();
        }
    }
}
