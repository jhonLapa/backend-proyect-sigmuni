using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FormaAdquisiciones.Maps
{
    public class FormaAdquisicionProfile : Profile
    {
        public FormaAdquisicionProfile()
        {
            CreateMap<FormaAdquisicion, FormaAdquisicionDto>();
            CreateMap<FormaAdquisicion, FormaAdquisicionDto>().ReverseMap();

            CreateMap<RequestPagination<FormaAdquisicion>, RequestPagination<FormaAdquisicionDto>>().ReverseMap();
            CreateMap<ResponsePagination<FormaAdquisicion>, ResponsePagination<FormaAdquisicionDto>>();
        }
    }
}
