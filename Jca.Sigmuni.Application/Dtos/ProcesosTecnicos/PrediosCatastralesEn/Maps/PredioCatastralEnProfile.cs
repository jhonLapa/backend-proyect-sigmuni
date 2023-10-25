using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn.Maps
{
    public class PredioCatastralEnProfile : Profile
    {
        public PredioCatastralEnProfile()
        {
            CreateMap<PredioCatastralEn, PredioCatastralEnDto>();
            CreateMap<PredioCatastralEn, PredioCatastralEnDto>().ReverseMap();

            CreateMap<RequestPagination<PredioCatastralEn>, RequestPagination<PredioCatastralEnDto>>().ReverseMap();
            CreateMap<ResponsePagination<PredioCatastralEn>, ResponsePagination<PredioCatastralEnDto>>();
        }
    }
}
