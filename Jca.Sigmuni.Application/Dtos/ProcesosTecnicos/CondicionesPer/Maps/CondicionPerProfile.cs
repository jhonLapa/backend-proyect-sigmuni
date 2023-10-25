using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer.Maps
{
    public class CondicionPerProfile : Profile
    {
        public CondicionPerProfile() 
        {
            CreateMap<CondicionPer, CondicionPerDto>();
            CreateMap<CondicionPer, CondicionPerDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionPer>, RequestPagination<CondicionPerDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionPer>, ResponsePagination<CondicionPerDto>>();
        }
    }
}
