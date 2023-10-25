using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes.Maps
{
    public class LoteDetalleProfile : Profile
    {
        public LoteDetalleProfile()
        {
            CreateMap<LoteDetalle, LoteDetalleDto>();
            CreateMap<LoteDetalle, LoteDetalleDto>().ReverseMap();
        }
    }
}
