using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes.Maps
{
    public class LoteProfile : Profile
    {
        public LoteProfile()
        {
            CreateMap<Lote, LoteDto>();
            CreateMap<Lote, LoteDto>().ReverseMap();

            CreateMap<RequestPagination<Lote>, RequestPagination<LoteDto>>().ReverseMap();
            CreateMap<ResponsePagination<Lote>, ResponsePagination<LoteDto>>();
        }
    }
}
