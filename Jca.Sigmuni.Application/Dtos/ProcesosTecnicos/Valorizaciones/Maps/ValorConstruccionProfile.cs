using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones.Maps
{
    public class ValorConstruccionProfile : Profile
    {
        public ValorConstruccionProfile()
        {
            CreateMap<Construccion, ValorConstruccionDto>()
                .AfterMap<ValorConstruccionProfileAction>();
        }
    }
}
