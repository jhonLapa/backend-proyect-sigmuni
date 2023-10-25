using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales.Maps
{
    public class CotitularCatastralProfile : Profile
    {
        public CotitularCatastralProfile()
        {
            CreateMap<TitularCatastral, CotitularCatastralDto>()
                .AfterMap<CotitularCatastralProfileAction>();
        }
    }
}
