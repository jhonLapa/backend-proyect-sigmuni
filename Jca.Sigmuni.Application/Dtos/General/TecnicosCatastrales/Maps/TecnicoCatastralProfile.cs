using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;


namespace Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales.Maps
{
    public class TecnicoCatastralProfile : Profile
    {
        public TecnicoCatastralProfile()
        {
            CreateMap<TecnicoCatastral, TecnicoCatastralDto>();
            CreateMap<TecnicoCatastral, TecnicoCatastralDto>().ReverseMap();

            CreateMap<RequestPagination<TecnicoCatastral>, RequestPagination<TecnicoCatastralDto>>().ReverseMap();
            CreateMap<ResponsePagination<TecnicoCatastral>, ResponsePagination<TecnicoCatastralDto>>();
        }
    }
}
