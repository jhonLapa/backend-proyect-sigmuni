using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TblCodigos.Maps
{
    public class TblCodigoCatastralProfile : Profile
    {
        public TblCodigoCatastralProfile()
        {
            CreateMap<TblCodigo, TblCodigoCatastralDto>();
            CreateMap<TblCodigo, TblCodigoCatastralDto>().ReverseMap();

            CreateMap<RequestPagination<TblCodigo>, RequestPagination<TblCodigoCatastralDto>>().ReverseMap();
            CreateMap<ResponsePagination<TblCodigo>, ResponsePagination<TblCodigoCatastralDto>>();
        }
    }
}
