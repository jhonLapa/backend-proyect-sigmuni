using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.InfoContactos.Maps
{
    public class InfoContactoFormProfile : Profile
    {
        public InfoContactoFormProfile() 
        {
            CreateMap<InfoContacto, InfoContactoFormDto>().ReverseMap();
        }
    }
}
