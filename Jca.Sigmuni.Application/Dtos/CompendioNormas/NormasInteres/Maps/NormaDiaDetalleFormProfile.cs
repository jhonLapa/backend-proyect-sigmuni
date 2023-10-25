using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaDiaDetalleFormProfile : Profile
    {
        public NormaDiaDetalleFormProfile()
        {
            CreateMap<NormaDiaDetalle, NormaDiaDetalleFormDto>().ReverseMap();
        }
    }
}
