using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Sectores.Maps
{
    public class SectorProfile : Profile
    {
        
            public SectorProfile()
            {
                CreateMap<Sector, SectorDto>();
                CreateMap<Sector, SectorDto>().ReverseMap();

                CreateMap<RequestPagination<Sector>, RequestPagination<SectorDto>>().ReverseMap();
                CreateMap<ResponsePagination<Sector>, ResponsePagination<SectorDto>>();
            }
        
    }
}
