using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ExoneracionPredios.Maps
{
    public class ExoneracionPredioProfile : Profile
    {
        public ExoneracionPredioProfile()
        {
            CreateMap<ExoneracionPredio, ExoneracionPredioDto>();
        }
    }
}
