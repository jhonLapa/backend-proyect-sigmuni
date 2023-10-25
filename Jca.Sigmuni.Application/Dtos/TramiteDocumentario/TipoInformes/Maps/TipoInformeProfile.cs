using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInformes.Maps
{
    public class TipoInformeProfile : Profile
    {
        public TipoInformeProfile()
        {
            CreateMap<TipoInforme, TipoInformeDto>();
            CreateMap<TipoInforme, TipoInformeDto>().ReverseMap();

            CreateMap<RequestPagination<TipoInforme>, RequestPagination<TipoInformeDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoInforme>, ResponsePagination<TipoInformeDto>>();
        }
    }
}
