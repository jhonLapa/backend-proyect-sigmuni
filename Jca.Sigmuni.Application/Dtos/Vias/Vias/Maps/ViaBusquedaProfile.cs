using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Vias.Vias.Maps
{
    public class ViaBusquedaProfile : Profile
    {
        public ViaBusquedaProfile()
        {
            CreateMap<Via, ViaBusquedaDto>();
            CreateMap<Via, ViaBusquedaDto>().ReverseMap();

            CreateMap<RequestPagination<Via>, RequestPagination<ViaBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Via>, ResponsePagination<ViaBusquedaDto>>();
        }
    }
}
