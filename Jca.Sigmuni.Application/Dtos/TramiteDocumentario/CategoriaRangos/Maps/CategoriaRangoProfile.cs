using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos.Maps
{
    public class CategoriaRangoProfile : Profile
    {
        public CategoriaRangoProfile()
        {

            CreateMap<CategoriaRango, CategoriaRangoConsultarDto>();
            CreateMap<CategoriaRango, CategoriaRangoConsultarDto>().ReverseMap();

            CreateMap<CategoriaRango, CategoriaRangoDto>();
            CreateMap<CategoriaRango, CategoriaRangoDto>().ReverseMap();

            CreateMap<RequestPagination<CategoriaRango>, RequestPagination<CategoriaRangoDto>>().ReverseMap();
            CreateMap<ResponsePagination<CategoriaRango>, ResponsePagination<CategoriaRangoDto>>();
        }
    }
}
