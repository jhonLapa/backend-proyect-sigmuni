using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles.Maps
{
    public class IntervencionInmuebleProfile : Profile
    {
        public IntervencionInmuebleProfile()
        {
            CreateMap<IntervencionInmueble, IntervencionInmuebleDto>();
            CreateMap<IntervencionInmueble, IntervencionInmuebleDto>().ReverseMap();

            CreateMap<RequestPagination<IntervencionInmueble>, RequestPagination<IntervencionInmuebleDto>>().ReverseMap();
            CreateMap<ResponsePagination<IntervencionInmueble>, ResponsePagination<IntervencionInmuebleDto>>();
        }
    }
}
