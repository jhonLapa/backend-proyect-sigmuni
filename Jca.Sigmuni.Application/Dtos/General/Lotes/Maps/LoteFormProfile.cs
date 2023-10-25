using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes.Maps
{
    public class LoteFormProfile : Profile
    {
        public LoteFormProfile()
        {

            CreateMap<Lote, LoteFormDto>();
            CreateMap<Lote, LoteFormDto>().ReverseMap();

            CreateMap<RequestPagination<Lote>, RequestPagination<LoteFormDto>>().ReverseMap();
            CreateMap<ResponsePagination<Lote>, ResponsePagination<LoteFormDto>>();
        }
    }
}
