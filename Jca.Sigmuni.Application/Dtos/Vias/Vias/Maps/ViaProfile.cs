using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;

namespace Jca.Sigmuni.Application.Dtos.Vias.Vias.Maps
{
    public class ViaProfile : Profile
    {
        public ViaProfile()
        {
            CreateMap<Via, ViaDto>();
            CreateMap<Via, ViaDto>().ReverseMap();

            CreateMap<RequestPagination<Via>, RequestPagination<ViaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Via>, ResponsePagination<ViaDto>>();
        }
    }
}
