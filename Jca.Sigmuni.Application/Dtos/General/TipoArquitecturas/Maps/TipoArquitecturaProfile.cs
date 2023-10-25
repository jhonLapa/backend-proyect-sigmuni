using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas.Maps
{
    public class TipoArquitecturaProfile : Profile
    {
        public TipoArquitecturaProfile()
        {
            CreateMap<TipoArquitectura, TipoArquitecturaDto>();
            CreateMap<TipoArquitectura, TipoArquitecturaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoArquitectura>, RequestPagination<TipoArquitecturaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoArquitectura>, ResponsePagination<TipoArquitecturaDto>>();
        }
    }
}
