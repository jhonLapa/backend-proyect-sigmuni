using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IAreaTerrenoInvalidService
    {
        Task<AreaTerrenoInvalid> CreateAreaTerreno(AreaTerrenoInvalidDto entity);
    }
}
