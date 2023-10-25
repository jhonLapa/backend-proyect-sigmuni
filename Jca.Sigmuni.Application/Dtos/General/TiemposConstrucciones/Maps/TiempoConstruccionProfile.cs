using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones.Maps
{
    public class TiempoConstruccionProfile : Profile
    {
        public TiempoConstruccionProfile()
        {
            CreateMap<TiempoConstruccion, TiempoConstruccionDto>();
            CreateMap<TiempoConstruccion, TiempoConstruccionDto>().ReverseMap();

            CreateMap<RequestPagination<TiempoConstruccion>, RequestPagination<TiempoConstruccionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TiempoConstruccion>, ResponsePagination<TiempoConstruccionDto>>();
        }
    }
}
