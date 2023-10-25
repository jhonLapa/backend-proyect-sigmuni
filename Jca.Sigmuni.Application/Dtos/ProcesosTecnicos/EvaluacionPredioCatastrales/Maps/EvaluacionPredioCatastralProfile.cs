using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales.Maps
{
    public class EvaluacionPredioCatastralProfile : Profile
    {
        public EvaluacionPredioCatastralProfile()
        {
            CreateMap<EvaluacionPredioCatastral, EvaluacionPredioCatastralDto>();
        }
    }
}
