using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores.Maps
{
    public class MarcadorProfile : Profile
    {
        public MarcadorProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.Marcador, MarcadorDto>();
            CreateMap<Domain.ArchivoDocumentario.Marcador, MarcadorDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.Marcador>, RequestPagination<MarcadorDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.Marcador>, ResponsePagination<MarcadorDto>>();
        }
    }
}
