using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones.Maps
{
    public class CategoriaConstruccionProfile : Profile
    {
        public CategoriaConstruccionProfile()
        {
            CreateMap<CategoriaConstruccion, CategoriaConstruccionDto>();
            CreateMap<CategoriaConstruccion, CategoriaConstruccionDto>().ReverseMap();

            CreateMap<RequestPagination<CategoriaConstruccion>, RequestPagination<CategoriaConstruccionDto>>().ReverseMap();
            CreateMap<ResponsePagination<CategoriaConstruccion>, ResponsePagination<CategoriaConstruccionDto>>();
        }
    }
}
