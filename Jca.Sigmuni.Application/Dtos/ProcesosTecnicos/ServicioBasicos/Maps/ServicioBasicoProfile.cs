using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos.Maps
{
    public class ServicioBasicoProfile : Profile
    {
        public ServicioBasicoProfile()
        {
            CreateMap<ServicioBasico, ServicioBasicoDto>()
                .AfterMap<ServicioBasicoProfileAction>();
        }
    }
}
