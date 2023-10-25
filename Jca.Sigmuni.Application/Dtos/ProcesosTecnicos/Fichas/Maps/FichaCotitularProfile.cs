using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class FichaCotitularProfile : Profile
    {
        public FichaCotitularProfile()
        {
            CreateMap<Ficha, FichaCotitularFormDto>();
            CreateMap<Ficha, FichaCotitularFormDto>().ReverseMap();

            CreateMap<RequestPagination<Ficha>, RequestPagination<FichaCotitularFormDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ficha>, ResponsePagination<FichaCotitularFormDto>>();
        }
    }
}
