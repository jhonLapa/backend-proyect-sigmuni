using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Jurisdiccion;

namespace Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes.Maps
{
    public class JurisdiccionLoteProfile : Profile
    {
        public JurisdiccionLoteProfile()
        {
           // CreateMap<JurisdiccionLote, JurisdiccionLoteDto>()
             // .AfterMap<JurisdiccionLoteProfileAction>();

             CreateMap<JurisdiccionLote, JurisdiccionLoteDto>()
                .AfterMap<JurisdiccionLoteProfileAction>(); 
            CreateMap<JurisdiccionLote, JurisdiccionLoteDto>().ReverseMap();

            CreateMap<RequestPagination<JurisdiccionLote>, RequestPagination<JurisdiccionLoteDto>>().ReverseMap();
            CreateMap<ResponsePagination<JurisdiccionLote>, ResponsePagination<JurisdiccionLoteDto>>();
                
        }
    }
}
