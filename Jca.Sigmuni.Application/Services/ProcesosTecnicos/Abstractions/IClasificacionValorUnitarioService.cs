using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IClasificacionValorUnitarioService
    {
        Task<IList<ClasificacionValorUnitarioDto>> FindAll();
    }
}
