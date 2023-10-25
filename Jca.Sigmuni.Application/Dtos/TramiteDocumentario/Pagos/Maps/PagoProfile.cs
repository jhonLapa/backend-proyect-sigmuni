using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Pagos.Maps
{
    public class PagoProfile:Profile
    {
        public PagoProfile()
        {
            CreateMap<Pago, PagoDto>();
            CreateMap<Pago, PagoDto>().ReverseMap();
        }
    }
}
