using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDigitacions.Maps
{
    public class TipoDigitacionProfile : Profile
    {
        public TipoDigitacionProfile()
        {
            CreateMap<TipoDigitacion, TipoDigitacionDto>();
            CreateMap<TipoDigitacion, TipoDigitacionDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDigitacion>, RequestPagination<TipoDigitacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDigitacion>, ResponsePagination<TipoDigitacionDto>>();
        }
    }
}
