using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TipoMateriales.Maps
{
    public class TipoMaterialProfile : Profile
    {
        public TipoMaterialProfile()
        {
            CreateMap<TipoMaterial, TipoMaterialDto>();
            CreateMap<TipoMaterial, TipoMaterialDto>().ReverseMap();

            CreateMap<RequestPagination<TipoMaterial>, RequestPagination<TipoMaterialDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoMaterial>, ResponsePagination<TipoMaterialDto>>();
        }
    }
}
