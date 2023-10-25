using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias.Maps
{
    public class ValorObraComplementariaProfile : Profile
    {
        public ValorObraComplementariaProfile()
        {
            CreateMap<ValorObraComplementaria, ValorObraComplementariaDto>();
            CreateMap<ValorObraComplementaria, ValorObraComplementariaDto>().ReverseMap();

            CreateMap<RequestPagination<ValorObraComplementaria>, RequestPagination<ValorObraComplementariaDto>>().ReverseMap();
            CreateMap<ResponsePagination<ValorObraComplementaria>, ResponsePagination<ValorObraComplementariaDto>>();
        }
    }
}
