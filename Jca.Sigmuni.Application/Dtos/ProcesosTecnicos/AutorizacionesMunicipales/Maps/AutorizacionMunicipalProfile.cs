using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales.Maps
{
    public class AutorizacionMunicipalProfile : Profile
    {
        public AutorizacionMunicipalProfile()
        {
            CreateMap<AutorizacionMunicipal, AutorizacionMunicipalDto>();
            CreateMap<AutorizacionMunicipal, AutorizacionMunicipalDto>().ReverseMap();

            CreateMap<RequestPagination<AutorizacionMunicipal>, RequestPagination<AutorizacionMunicipalDto>>().ReverseMap();
            CreateMap<ResponsePagination<AutorizacionMunicipal>, ResponsePagination<AutorizacionMunicipalDto>>();
        }
    }
}
