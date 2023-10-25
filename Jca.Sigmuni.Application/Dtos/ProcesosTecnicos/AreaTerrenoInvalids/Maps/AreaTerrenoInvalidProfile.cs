using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids.Maps
{
    public class AreaTerrenoInvalidProfile:Profile
    {
        public AreaTerrenoInvalidProfile() 
        {
            CreateMap<AreaTerrenoInvalid,AreaTerrenoInvalidDto>();
            CreateMap<AreaTerrenoInvalid, AreaTerrenoInvalidDto>().ReverseMap();
        }
    }
}
