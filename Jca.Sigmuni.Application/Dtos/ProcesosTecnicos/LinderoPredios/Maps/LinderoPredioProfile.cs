using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.LinderoPredios.Maps
{
    public class LinderoPredioProfile : Profile
    {
        public LinderoPredioProfile()
        {
            CreateMap<LinderoPredio, LinderoPredioDto>();
        }
    }
}
