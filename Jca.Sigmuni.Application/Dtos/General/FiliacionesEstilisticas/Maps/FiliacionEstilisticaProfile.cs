using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.FiliacionesEstilisticas.Maps
{
    public class FiliacionEstilisticaProfile : Profile
    {
        public FiliacionEstilisticaProfile()
        {
            CreateMap<FiliacionEstilistica, FiliacionEstilisticaDto>();
            CreateMap<FiliacionEstilistica, FiliacionEstilisticaDto>().ReverseMap();

            CreateMap<RequestPagination<FiliacionEstilistica>, RequestPagination<FiliacionEstilisticaDto>>().ReverseMap();
            CreateMap<ResponsePagination<FiliacionEstilistica>, ResponsePagination<FiliacionEstilisticaDto>>();
        }
    }
}
