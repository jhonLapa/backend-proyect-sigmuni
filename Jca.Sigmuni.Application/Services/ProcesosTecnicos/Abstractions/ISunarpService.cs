using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ISunarpService
    {
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
        Task<Sunarp> CrearAsync(SunarpDto peticion);
    }
}
