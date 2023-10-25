using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles.Maps
{
    public class CategoriaInmuebleProfile : Profile
    {
        public CategoriaInmuebleProfile()
        {
            CreateMap<CategoriaInmueble, CategoriaInmuebleDto>();
            CreateMap<CategoriaInmueble, CategoriaInmuebleDto>().ReverseMap();

            CreateMap<RequestPagination<CategoriaInmueble>, RequestPagination<CategoriaInmuebleDto>>().ReverseMap();
            CreateMap<ResponsePagination<CategoriaInmueble>, ResponsePagination<CategoriaInmuebleDto>>();
        }
    }
}
