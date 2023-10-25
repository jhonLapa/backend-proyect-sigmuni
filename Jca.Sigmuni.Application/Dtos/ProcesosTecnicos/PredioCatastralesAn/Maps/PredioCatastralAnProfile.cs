using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn.Maps
{
    public class PredioCatastralAnProfile : Profile
    {
        public PredioCatastralAnProfile()
        {
            CreateMap<PredioCatastralAn, PredioCatastralAnDto>();
            CreateMap<PredioCatastralAn, PredioCatastralAnDto>().ReverseMap();

            CreateMap<RequestPagination<PredioCatastralAn>, RequestPagination<PredioCatastralAnDto>>().ReverseMap();
            CreateMap<ResponsePagination<PredioCatastralAn>, ResponsePagination<PredioCatastralAnDto>>();
        }
    }
}
