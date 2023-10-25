using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales.Maps
{
    public class RegistroLegalProfile : Profile
    {
        public RegistroLegalProfile()
        {
            CreateMap<RegistroLegal, RegistroLegalDto>();
        }
    }
}
