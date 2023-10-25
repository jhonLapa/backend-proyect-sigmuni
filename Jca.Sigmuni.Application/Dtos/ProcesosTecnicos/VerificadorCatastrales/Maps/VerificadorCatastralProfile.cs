using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales.Maps
{
    public class VerificadorCatastralProfile : Profile
    {
        public VerificadorCatastralProfile()
        {
            CreateMap<Persona, VerificadorCatastralDto>()
                .AfterMap<VerificadorCatastralProfileAction>();
        }
    }
}
