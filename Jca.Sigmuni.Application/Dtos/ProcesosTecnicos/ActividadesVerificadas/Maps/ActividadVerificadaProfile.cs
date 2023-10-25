using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesVerificadas.Maps
{
    public class ActividadVerificadaProfile : Profile
    {
        public ActividadVerificadaProfile()
        {
            CreateMap<ActividadVerificada, ActividadVerificadaDto>();
            CreateMap<ActividadVerificada, ActividadVerificadaDto>().ReverseMap();

            CreateMap<RequestPagination<ActividadVerificada>, RequestPagination<ActividadVerificadaDto>>().ReverseMap();
            CreateMap<ResponsePagination<ActividadVerificada>, ResponsePagination<ActividadVerificadaDto>>();
        }
    }
}
