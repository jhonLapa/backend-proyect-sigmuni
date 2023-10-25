using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoPresentados.Maps
{
    public class TipoDocumentoPresentadoProfile : Profile
    {
        public TipoDocumentoPresentadoProfile()
        {
            CreateMap<TipoDocumentoPresentado, TipoDocumentoPresentadoDto>();
            CreateMap<TipoDocumentoPresentado, TipoDocumentoPresentadoDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDocumentoPresentado>, RequestPagination<TipoDocumentoPresentadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDocumentoPresentado>, ResponsePagination<TipoDocumentoPresentadoDto>>();
        }
    }
}