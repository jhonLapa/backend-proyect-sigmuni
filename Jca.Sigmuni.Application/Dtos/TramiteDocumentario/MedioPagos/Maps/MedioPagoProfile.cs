using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioPagos.Maps
{
    public class MedioPagoProfile : Profile
    {
        public MedioPagoProfile()
        {
            CreateMap<MedioPago, MedioPagoDto>();
            CreateMap<MedioPago, MedioPagoDto>().ReverseMap();

            CreateMap<RequestPagination<MedioPago>, RequestPagination<MedioPagoDto>>().ReverseMap();
            CreateMap<ResponsePagination<MedioPago>, ResponsePagination<MedioPagoDto>>();
        }
    }
}
