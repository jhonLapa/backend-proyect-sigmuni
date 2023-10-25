using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Ubigeos.Maps
{
    public class UbigeoProfile : Profile
    {
        public UbigeoProfile()
        {
            CreateMap<Ubigeo, UbigeoDto>();
            CreateMap<Ubigeo, UbigeoDto>().ReverseMap();

            CreateMap<RequestPagination<Ubigeo>, RequestPagination<UbigeoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ubigeo>, ResponsePagination<UbigeoDto>>();
        }
    }
}
