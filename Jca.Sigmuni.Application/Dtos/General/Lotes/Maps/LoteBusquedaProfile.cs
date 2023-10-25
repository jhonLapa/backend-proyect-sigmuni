using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes.Maps
{
    public class LoteBusquedaProfile : Profile
    {
        public LoteBusquedaProfile()
        {

            CreateMap<LoteBusqueda, LoteBusquedaDto>();
            CreateMap<LoteBusqueda, LoteBusquedaDto>().ReverseMap();

            CreateMap<RequestPagination<LoteBusqueda>, RequestPagination<LoteBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<LoteBusqueda>, ResponsePagination<LoteBusquedaDto>>();
        }
    }
}
