using AutoMapper;
using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios.Maps
{
    public class DomicilioTitularProfile : Profile
    {
        public DomicilioTitularProfile()
        {
            CreateMap<Domicilio, DomicilioTitularCatastralDto>()
                .AfterMap<DomicilioTitularProfileAction>();
        }
    }
}
