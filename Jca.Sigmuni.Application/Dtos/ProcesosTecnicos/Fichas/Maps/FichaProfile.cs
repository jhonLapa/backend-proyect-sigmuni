using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class FichaProfile : Profile
    {
        public FichaProfile() 
        {
            CreateMap<Ficha, FichaDto>();
            CreateMap<Ficha, FichaDto>().ReverseMap();

            CreateMap<RequestPagination<Ficha>, RequestPagination<FichaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ficha>, ResponsePagination<FichaDto>>();
        }
    }
}
