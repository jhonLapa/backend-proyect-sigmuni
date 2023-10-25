using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss.Maps
{
    public class EcsProfile : Profile
    {
        public EcsProfile()
        {
            CreateMap<Ecs, EcsDto>();
            CreateMap<Ecs, EcsDto>().ReverseMap();

            CreateMap<RequestPagination<Ecs>, RequestPagination<EcsDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ecs>, ResponsePagination<EcsDto>>();
        }
    }
}
