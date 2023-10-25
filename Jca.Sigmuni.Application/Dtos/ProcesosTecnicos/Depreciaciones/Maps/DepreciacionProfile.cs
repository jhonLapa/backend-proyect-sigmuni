using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones.Maps
{
    public class DepreciacionProfile : Profile
    {
        public DepreciacionProfile()
        {
            CreateMap<Depreciacion, DepreciacionDto>()
                .AfterMap<DepreciacionProfileAction>();
            CreateMap<Depreciacion, DepreciacionDto>().ReverseMap();

            CreateMap<RequestPagination<Depreciacion>, RequestPagination<DepreciacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<Depreciacion>, ResponsePagination<DepreciacionDto>>();
        }
    }
}
