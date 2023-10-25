using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios.Maps
{
    public class ValorUnitarioProfile : Profile
    {
        public ValorUnitarioProfile()
        {
            CreateMap<ValorUnitario, ValorUnitarioDto>();
            CreateMap<ValorUnitario, ValorUnitarioDto>().ReverseMap();

            CreateMap<RequestPagination<ValorUnitario>, RequestPagination<ValorUnitarioDto>>().ReverseMap();
            CreateMap<ResponsePagination<ValorUnitario>, ResponsePagination<ValorUnitarioDto>>();
        }
    }
}
