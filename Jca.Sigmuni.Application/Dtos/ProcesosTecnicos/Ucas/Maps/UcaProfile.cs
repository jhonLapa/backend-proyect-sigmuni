using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas.Maps
{
    public class UcaProfile : Profile
    {
        public UcaProfile()
        {
            CreateMap<Uca, UcaDto>();
            CreateMap<Uca, UcaDto>().ReverseMap();

            CreateMap<RequestPagination<Uca>, RequestPagination<UcaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Uca>, ResponsePagination<UcaDto>>();
        }
    }
}
