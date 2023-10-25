using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Naturalezas.Maps
{
    public class NaturalezaProfile:Profile
    {
        public NaturalezaProfile() {
            CreateMap < Naturaleza, NaturalezaDto>();
            CreateMap<Naturaleza, NaturalezaDto>().ReverseMap();

            CreateMap<RequestPagination<Naturaleza>, RequestPagination<NaturalezaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Naturaleza>, ResponsePagination<NaturalezaDto>>();
        }
    }
}
