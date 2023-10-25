using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInspectors.Maps
{
    public class TipoInspectorProfile : Profile
    {
        public TipoInspectorProfile()
        {
            CreateMap<TipoInspector, TipoInspectorDto>();
            CreateMap<TipoInspector, TipoInspectorDto>().ReverseMap();

            CreateMap<RequestPagination<TipoInspector>, RequestPagination<TipoInspectorDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoInspector>, ResponsePagination<TipoInspectorDto>>();
        }
    }
}
