using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos.Maps
{
    public class ProcedimientoRequisitoProfile : Profile
    {
        public ProcedimientoRequisitoProfile()
        {
            CreateMap<ProcedimientoRequisito, ProcedimientoRequisitoDto>();
            CreateMap<ProcedimientoRequisito, ProcedimientoRequisitoDto>().ReverseMap();

            CreateMap<RequestPagination<ProcedimientoRequisito>, RequestPagination<ProcedimientoRequisitoDto>>().ReverseMap();
            CreateMap<ResponsePagination<ProcedimientoRequisito>, ResponsePagination<ProcedimientoRequisitoDto>>();
        }
    }

}
