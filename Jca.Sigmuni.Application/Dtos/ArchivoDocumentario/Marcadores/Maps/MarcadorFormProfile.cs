using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores.Maps
{
    public class MarcadorFormProfile : Profile
    {
        public MarcadorFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.Marcador, MarcadorFormDto>().ReverseMap();
        }
    }
}
