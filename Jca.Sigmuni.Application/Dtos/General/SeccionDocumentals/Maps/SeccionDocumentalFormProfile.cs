using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals.Maps
{
    public class SeccionDocumentalFormProfile : Profile
    {
        public SeccionDocumentalFormProfile()
        {
            CreateMap<Domain.General.SeccionDocumental, SeccionDocumentalDto>().ReverseMap();
        }
    }
}
