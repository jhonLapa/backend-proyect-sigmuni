using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas.Maps
{
    public class FiliacionCronologicaProfile : Profile
    {
        public FiliacionCronologicaProfile()
        {
            CreateMap<FiliacionCronologica, FiliacionCronologicaDto>();
            CreateMap<FiliacionCronologica, FiliacionCronologicaDto>().ReverseMap();

            CreateMap<RequestPagination<FiliacionCronologica>, RequestPagination<FiliacionCronologicaDto>>().ReverseMap();
            CreateMap<ResponsePagination<FiliacionCronologica>, ResponsePagination<FiliacionCronologicaDto>>();
        }
    }
}
