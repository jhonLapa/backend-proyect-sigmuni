using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaDiaDetalleProfile : Profile
    {
        public NormaDiaDetalleProfile()
        {
            CreateMap<NormaDiaDetalle, NormaDiaDetalleDto>();
            CreateMap<NormaDiaDetalle, NormaDiaDetalleDto>().ReverseMap();

            CreateMap<RequestPagination<NormaDiaDetalle>, RequestPagination<NormaDiaDetalleDto>>().ReverseMap();
            CreateMap<ResponsePagination<NormaDiaDetalle>, ResponsePagination<NormaDiaDetalleDto>>();
        }
    }
}
