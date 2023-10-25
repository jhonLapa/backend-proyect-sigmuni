using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones.Maps
{
    public class CategoriaOrganizacionProfile : Profile
    {
        public CategoriaOrganizacionProfile()
        {
            CreateMap<CategoriaOrganizacion, CategoriaOrganizacionDto>();
            CreateMap<CategoriaOrganizacion, CategoriaOrganizacionDto>().ReverseMap();

            CreateMap<RequestPagination<CategoriaOrganizacion>, RequestPagination<CategoriaOrganizacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<CategoriaOrganizacion>, ResponsePagination<CategoriaOrganizacionDto>>();
        }
    }
}
