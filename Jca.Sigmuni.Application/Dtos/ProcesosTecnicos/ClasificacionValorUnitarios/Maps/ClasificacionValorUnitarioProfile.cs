using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios.Maps
{
    public class ClasificacionValorUnitarioProfile : Profile
    {
        public ClasificacionValorUnitarioProfile()
        {
            CreateMap<ClasificacionValorUnitario, ClasificacionValorUnitarioDto>();
        }
    }
}
