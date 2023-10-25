using AutoMapper;
using Jca.Sigmuni.Domain.Zonificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros.Maps
{
    public class LoteZonificacionParametroProfile : Profile
    {
        public LoteZonificacionParametroProfile()
        {
            CreateMap<LoteZonificacionParametro, LoteZonificacionParametroDto>()
                .AfterMap<LoteZonificacionParametroProfileAction>();
        }
    }
}